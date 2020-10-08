using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetCurd.Models;

namespace AspNetCurd.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (DBModel db= new DBModel())
            {
                List<TblEmployee> empList = db.TblEmployees.ToList<TblEmployee>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddorEdit(int id=0)
        {
            return View(new TblEmployee());
        }
        [HttpPost]
        public ActionResult AddorEdit(TblEmployee emp)
        {
            using (DBModel db=new DBModel())
            {
                db.TblEmployees.Add(emp);
                db.SaveChanges();
                return Json(new { success=true, message="Saved Successfully" },JsonRequestBehavior.AllowGet);
            }

        }







    }
}
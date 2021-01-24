public ActionResult Index()
{
     dbcontext db = new dbcontext();
     return View(db.EmployeeDetails.ToList());
}
To get  JSON
public System.Web.Mvc.JsonResult GetEmployeeInJSON()
{
     dbcontext db = new dbcontext();
     var data = db.EmployeeDetails.ToList();
     return Json(data, JsonRequestBehavior.AllowGet);
}

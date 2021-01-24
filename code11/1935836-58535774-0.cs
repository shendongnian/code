public ActionResult Index()
{
     dbcontext db = new dbcontext();
     return View(db.EmployeeDetails.ToList());
}

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
If you are trying to use it in webapi. use following code.
While calling api, set Content-Type = "application/json"
[HttpGet]
[Route("AllEmployeeDetailsInJSON")]
public async Task<HttpResponseMessage> GetEmployeeInJSON()
{   
	try
	{
		dbcontext db = new dbcontext();
		var data = db.EmployeeDetails.ToList();
		return Request.CreateResponse(HttpStatusCode.OK, new
		{
			Data = data
		});
	}
	catch (Exception)
	{
		throw;
	}
}

    // Controller/Action
    [HttpGet]
    public ActionResult IAmSpecial()
    {
    	if (Request.IsAjaxRequest())
    	{
    		string[] objects = new string[] { "Foo", "Bar" };
    
    		return Json(objects);
    	}
    
    	return View();
    }

    public ActionResult AjaxTest(AppModel model)
    {
    	if (model.status == "ReturnView")
    	{
    		jsonMessage = new { param1 = "param1", param2 = "param2", param3 = "param3" };
    		string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonMessage);
    		HttpContext.Response.AddHeader("srchMessage", jsonString);
    		HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
    		return View(model);
    	}
    	
    	if (model.status == "ReturnJSON")
    	{
    		jsonMessage = new { param1 = "param1", param2 = "param2", param3 = "param3" };
    		HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
    		return Json(jsonMessage, JsonRequestBehavior.AllowGet);
    	}
    }

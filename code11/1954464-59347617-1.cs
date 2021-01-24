    [HttpGet]
    public ActionResult AAA()
    {
       return RedirectToAction("BBB"); 
    }
    
    [HttpGet]
    public JsonResult BBB()
    {
        bool success = false;
        string sMessage = "Call from BBB Function";   
        return Json(new { success = true, response = sMessage }, JsonRequestBehavior.AllowGet);        
    }

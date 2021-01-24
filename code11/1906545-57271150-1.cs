       var testData= (string)Session["testData"]
     
       return RedirectToAction("actionName", "ControllerName", new{ data: data})
       public ActionResult actionName(string data = "")
       {
         return View();
       }

        public ActionResult Index()
        {
            
            if (TempData["MyGlobalVariable"] == null)
                return RedirectToAction("MyGlobalVariableInitializer");
            else
                TempData["MyGlobalVariable"] =(string)TempData["MyGlobalVariable"]+" world";
         .
         .
         .
         }

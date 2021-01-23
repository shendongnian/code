        public ActionResult CompanySelection()
        {
            return View();
        }
        
        public ActionResult MyGlobalVariableInitializer()
        {
            TempData["MyGlobalVariable"] = "Hello";
            return RedirectToAction("Index");
        }

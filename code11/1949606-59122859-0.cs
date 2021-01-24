    [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(string number)
        {
            //your business code 
            TempData["FirstStepDone"] = true;
            // return RedirectTo()
        }
        public ActionResult Step2()
        {
            if (TempData["FirstStepDone"] == null)
                //return error
            return View();
        }

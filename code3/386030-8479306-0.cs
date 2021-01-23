        [HttpPost]       
        public ActionResult Create(ViewModel viewModel)
        {
            this.TempData["profile"] = viewModel;
            return RedirectToAction("Preview");
        }
        public ActionResult Preview()
        {            
           
            if (TempData["profile"] != null)
            {
                return View((ViewModel)TempData["profile"]);
            }
            
            // Handle invalid request...
            return null;
        }

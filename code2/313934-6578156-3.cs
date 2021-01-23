        public ActionResult MyAction()
        {
            // Do Some stuff
            //...
            
            // If the request is an ajax one, return the partial view
            if (Request.IsAjaxRequest())
                return PartialView("PartialViewName");
            
            // Else return the normal view
            return View();
        }

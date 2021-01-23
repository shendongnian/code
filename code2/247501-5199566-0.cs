    [GridAction]
        public ActionResult AjaxIndex()
        {
            // Get all of the orders
            return View(new GridModel(orderBll.GetAll()));
        }

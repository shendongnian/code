     [HandleError]
        public ActionResult Index()
        {
            // Test to see if you need to go to the SuppliersController
            if (this.User.IsInRole("supplier"))
            {
                return Redirect("/Suppliers/Error");
            }
            else
            {
                ViewBag.Message = "Cant find the page your looking for"
                return View(); // This returns the "Error" View from the shared folder
            }
        }

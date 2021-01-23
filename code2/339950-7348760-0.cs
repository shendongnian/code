     [HandleError]
        public ActionResult Index()
        {
            if (this.User.IsInRole("supplier"))
            {
                return Redirect("/Suppliers/Error");
            }
            else
            {
                return View();
            }
        }

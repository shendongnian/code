        public ActionResult Index()
        {
            var model = new SomeViewModel()
            {
            };
            return View(model);
        }

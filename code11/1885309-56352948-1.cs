    [HttpPost]
        public ActionResult Index(Home model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            TempData["model"] = model;
            return View("Foo");
        }

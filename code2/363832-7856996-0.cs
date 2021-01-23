        [HttpGet]
        public ActionResult TestForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestForm(FormCollection collection)
        {
            var model = new TestModel();
            TryUpdateModel(model, collection);
            Response.Write("[" + model.TestInput + "]");
            return View();
        }

    public ActionResult Index() {
            var model = new TestModel();
            model.Color="Blue";
            ViewData["Colors"]=new List<SelectListItem>() { new SelectListItem() { Text =  "Blue", Value = "Blue" }, new SelectListItem() { Text = "Red", Value = "Red" } };
            
            return View(model);
        }
    [HttpPost]
    public ActionResult Index(TestModel model) {
            model.Color="Red";
            ViewData["Colors"]=new List<SelectListItem>() { new SelectListItem() { Text =  "Blue", Value = "Blue" }, new SelectListItem() { Text = "Red", Value = "Red" } };
            ***ModelState.Clear();***
            return View(model);
    }

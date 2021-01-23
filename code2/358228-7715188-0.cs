    public ActionResult Index() {
            var model = new TestModel();
            model.Color="Blue";
            var colors =new List<SelectListItem>() { new SelectListItem() { Text =  "Blue", Value = "Blue" }, new SelectListItem() { Text = "Red", Value = "red" } };
            model.Colors = new SelectList(colors,"Text","Value");
    
            return View(model);
        }
    
    [HttpPost] public ActionResult Index(TestModel model) {
            model.Color="Red";
    
            var colors =new List<SelectListItem>() { new SelectListItem() { Text =  "Blue", Value = "Blue" }, new SelectListItem() { Text = "Red", Value = "red" } };
            model.Colors = new SelectList(colors,"Text","Value");
    
            return View(model); }

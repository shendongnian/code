    [HttpPost]
    public ActionResult Index(TestModel model) {
            model.Color="Red";
            var colors = new List<SelectListItem>() { new SelectListItem() { Text =  "Blue", Value = "Blue" }, new SelectListItem() { Text = "Red", Value = "Red" } };
            SelectListItem selectedColor = colors.Where(c => c.Text == model.Color).FirstOrDefault();
            if (selectedColor != null)
            {
                selectedColor.Selected = true;
            }
            else
            {
                colors.Add(new SelectListItem() { Text = model.Color; Value = model.Color; Selected = true; };
            }
            ViewData["Colors"] = colors;
            return View(model);
    }

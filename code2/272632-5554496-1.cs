    public ActionResult Foo()
    {
        var cats = _dal.GetSesionCategories();
        var model = new MyViewModel
        {
            // Preselect the category with id 2
            CategoryId = 2,
            // Ensure that cats has an item with id = 2
            Categories = cats.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
        };
    }

    public ActionResult Foo()
    {
        var model = new CategoryViewModel
        {
            Categories = 
                from c in new IntraEntities().CategoryItems.ToList()
                select new SelectListItem 
                {
                    Text = c.Name, 
                    Value = c.ID.ToString() 
                }
        };
        return View(model);
    }

    public ActionResult Index()
    {
        var categories = 
            (from category in context.Categories
             orderby category.SortOrder ascending
             select new CategoryViewModel
             {
                 Title = category.Title,
                 Products = category
                     .Products
                     .OrderBy(p => p.SortOrder)
                     .Select(p => new ProductViewModel
                     {
                         Description = p.Description
                     })
                 }).ToList(); 
            ).ToList();
        return View(categories);
    }

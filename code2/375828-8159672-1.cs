    IQueryable<Category> categoryQuery = db.Categories.Where(c=> /*if needed*/);
    List<Category> categories = categoryQuery.OrderBy(c => c.Order).ToList();
    categoryQuery.SelectMany(c => c.SubCategories)
      .OrderBy(sub => sub.Order)
      .AsEnumerable().Count(); // will just iterate (and add to context) all results

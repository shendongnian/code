    var query = _categoryService.GetCategories().Where(x => !x.ParentId.HasValue) // Getting only top level categories
                                                .OrderBy(x => x.DisplayOrder)     // Sorting
                                                .Select(x => new {
    Category = x,
    Articles = x.Articles.OrderByDesc(a => a.Published).Take(N))
    });

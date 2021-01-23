    // get the first part of the query
    IQueryable<Category> query = db.Categories
        .Where(category => category.ICG_PARENT_ID == parentId);
    
    // conditionally add the where clause
    if (parentId == 0)
    {
        var companyId = Convert.ToInt32(company);
        query = query.Where(category => category.ICG_COMPANY_ID == companyId);
    }
    
    // finish the query
    var jsTree = query
        .OrderBy(category => category.ICG_CATEGORY_NAME)
        .AsEnumerable() // use LINQ to Objects from this point on
        .Select(category => new JsTreeModel
         {
             data = category.ICG_CATEGORY_NAME,
             attr = new JsTreeAttribute { id = category.ICG_CATEGORY_ID.ToString() },
             state = "closed",
         }).ToArray();

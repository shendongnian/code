    var lookup =
        (from c in context.Categories
            .Include("ChildHierarchy")
            .Include("otherprop")
         join h in context.CategoryHierarchy
            on c.CategoryID equals h.ChildCategoryID
         select new { ParentCategoryID = h.ParentCategoryID, Category = c, }
        ).ToLookup(x => x.ParentCategoryID, x => x.Category);
    	
    var query =
        from c in context.Categories
            .Include("ChildHierarchy")
            .Include("otherprop")
        select new { Category = c, Children = lookup[c.CategoryID], };

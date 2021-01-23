    var Category = new [] { new SelectListItem {Text="All"}}
        .Concat(from cat in _db.Categories.ToList()
            select new SelectListItem {
                Text = cat.CategoryName
            ,   Value = cat.CategoryID.ToString()
            }
        ).ToList();

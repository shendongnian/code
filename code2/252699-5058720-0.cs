    var query = context.Categories
                .Include("ChildHierarchy")
                .Include("OtherProp")
                .Where(c => context.CategoryHierarchy.Where(ch => ch.ParentCategoryID == ch.ParentCategoryID)
                    .Select(ch => ch.ChildCategoryID).Contains(c.CategoryID))
                .Select(c => new { c.A, c.B, c.etc });

    // Load the category you want.
    var subCategory = db.Categories.Single(c => c.Id == 56);
    // Performance: Load the complete group in one go.
    var categories = (
        from category in db.Categories
        where category.GroupId == subCategory.GroupId
        select category)
        .ToArray();
    // Get the top most parent of the sub category.
    var parent = subCategory.GetParents().Last();
    // Extension method to get the parents.
    public static IEnumerable<Category> GetParents(this Category cat)
    {
        while (cat.Parent != null)
        {
            // NOTE: cat.Parent will not cause a database query
            // when the object is already in memory.
            yield return cat.Parent;
            cat = cat.Parent;
        }
    }

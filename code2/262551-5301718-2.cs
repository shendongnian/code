    // Load the category that will be used as starting point.
    var subCategory = db.Categories.Single(c => c.Id == 56);
    // Performance: Load the complete group in one go.
    var categories = (
        from category in db.Categories
        where category.GroupId == subCategory.GroupId
        select category)
        .ToArray();
    // Traverse the tree and get the top-most parent (if any).
    var parent = subCategory.GetParents().LastOrDefault();
    // Extension method to get the parents.
    public static IEnumerable<Category> GetParents(
        this Category category)
    {
        while (category.Parent != null)
        {
            // NOTE: cat.Parent will not cause a database call
            // when the Parent is already loaded by L2S.
            yield return cat.Parent;
            category = category.Parent;
        }
    }

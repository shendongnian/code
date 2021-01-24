    public IEnumerable<Category> GetChildlessCategories()
    {
        return WowContext.Categories
        .GroupJoin(
            WowContext.Categories.Where(category => category.ParentCategoryId.HasValue),
            (category) => category.CategoryId,
            (child) => child.ParentCategoryId.Value,
            (category, children) => new { Children = children, Category = category })
        .Where(a => !a.Children.Any())
        .Select(a => a.Category).ToList();
    }

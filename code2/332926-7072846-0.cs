    private void SaveCategoryRecursively(Category category)
    {
        foreach (var subCategory in category.SubCategories)
        {
            query(@"
    insert into [dbo].[Categories] ([Id], [ParentId], ...)
    values (@id, @parentId, ...)", ...);
            this.SaveCategoryRecursively(subCategory);
        }
    }
    public void SaveCategories(IEnumerable<Category> rootCategories)
    {
        foreach (var category in rootCategories)
        {
            query(@"
    insert into [dbo].[Categories] ([Id], [ParentId], ...)
    values (@id, NULL, ...)", ...);
            this.SaveCategoryRecursively(category);
        }
    }

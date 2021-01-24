    public List<CategoryVm> GetCategoriesTree(List<Category> categoriesList)
    {
        var categoriesTree = categoriesList.Where(category => category.ParentCategoryId == null)
            .Select(category => new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,
                SubCategories = new List<CategoryVm>()
            }).ToList();
        foreach (var category in categoriesTree)
        {
            FillSubCategories(category, categoriesList);
        }
        return categoriesTree;
    }
    private void FillSubCategories(CategoryVm categoryVm, List<Category> categoriesList)
    {
        var subCategories = categoriesList.Where(category => category.ParentCategoryId == categoryVm.Id).ToList();
        if (subCategories.Any())
        {
            categoryVm.SubCategories = subCategories.Select(category => new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,
                SubCategories = new List<CategoryVm>()
            }).ToList();
            foreach (var subCategory in categoryVm.SubCategories)
            {
                FillSubCategories(subCategory, categoriesList);
            }
        }
    }

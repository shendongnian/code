    model.Categories =
        productService.GetAllCategories().Select(
            c =>
                {
                    if (c.CategoryId == cat)
                        model.SelectedCategory = c.CategoryName;
                    return new CategoryViewModel
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName,
                        IsSelected = c.CategoryId == cat
                    }
                }).ToList();

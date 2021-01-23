    var viewModel = new PageViewModel();
    foreach (var category in db.Categories)
    {
        var categoryVM = new CategoryViewModel();
        foreach (var subcategory in category.SubCategories)
        {
            categoryVM.SubCategories.Add(....      
        }
    }

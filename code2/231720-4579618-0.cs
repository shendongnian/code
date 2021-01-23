    var selectList = listOfCategories.Select(x => new SelectListItem {
        Text = x.Name, 
        Value = x.Id.ToString() 
    }).ToList();
    var viewModel = new BlogModel
    {
        BlogId = blogToEdit.Id,
        Active = blogToEdit.Actief,
        Content = blogToEdit.Text,
        Title = blogToEdit.Titel,
        Categories = selectList,
        // this is what sets the selected value
        SelectedValue = blogToEdit.Category.Id 
    };

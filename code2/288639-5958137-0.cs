    public string SelectedCategory
    {
        get 
        {
            Category selected = Categories.SingleOrDefault(c => c.IsSelected);
            return (selected != null ? selected.CategoryName : String.Empty);
        }
    }

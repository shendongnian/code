    private void CboCategories_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        string categoryName = e.AddedItems[0].ToString();
        if (!string.IsNullOrEmpty(categoryName)
            && this.DataContext is SomeClass viewModel)
        {
            viewModel.GetFormNames(categoryName);
        }
    }

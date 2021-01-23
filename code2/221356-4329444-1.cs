    private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        var category = e.AddedItems.FirstOrDefault() as Category;
    
        if(category != null)
        {
            Mediator.Instance.SendMessage("Category Selected", category);
        }
    }

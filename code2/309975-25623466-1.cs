    private void dataGridName_Sorting(object sender, DataGridSortingEventArgs e)
    {
        var dgSender = (DataGrid) sender;
        var cView = CollectionViewSource.GetDefaultView(dgSender.ItemsSource);
       
        //Alternate between ascending/descending if the same column is clicked 
        ListSortDirection direction = ListSortDirection.Ascending;
        if (cView.SortDescriptions.FirstOrDefault().PropertyName == e.Column.SortMemberPath)
            direction = cView.SortDescriptions.FirstOrDefault().Direction == ListSortDirection.Descending ? ListSortDirection.Ascending : ListSortDirection.Descending;
        
        cView.SortDescriptions.Clear();
        AddSortColumn((DataGrid)sender, e.Column.SortMemberPath, direction);
        //To this point the default sort functionality is implemented
            
        //Now check the wanted columns and add multiple sort 
        if (e.Column.SortMemberPath == "WantedColumn")
        {
            AddSortColumn((DataGrid)sender, "SecondColumn", direction);
        }
        e.Handled = true;
    }
    private void AddSortColumn(DataGrid sender, string sortColumn, ListSortDirection direction)
    {
        var cView = CollectionViewSource.GetDefaultView(sender.ItemsSource);
        cView.SortDescriptions.Add(new SortDescription(sortColumn, direction));
        //Add the sort arrow on the DataGridColumn
        foreach (var col in sender.Columns.Where(x => x.SortMemberPath == sortColumn))
        {
            col.SortDirection = direction;
        }
    }

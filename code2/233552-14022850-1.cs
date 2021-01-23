    private void MyDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e) 
    {    // Only act on Commit
        if (e.EditAction == DataGridEditAction.Commit)
        {
             var newItem = e.Row.DataContext as MyDataboundType;
             if (newItem is NOT in my bound collection) ... handle insertion...
        } 
    }

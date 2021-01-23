    // just, add a new column
    ActualDataTable.Columns.Add("NullEmptyCheck", typeof(int), "ColumnNameToSort is Null OR ColumnNameToSort = ''");
    
    // apply sort expression
    ActualDataTable.DefaultView.Sort = "NullEmptyCheck asc, ColumnNameToSort asc";
    // pass datasource to grid
    MyGridView.DataSource = ActualDataTable.DefaultView;
    MyGridView.DataBind();

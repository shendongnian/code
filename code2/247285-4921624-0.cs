    // just, add a new column
    ActualDataTable.Columns.Add("NullEmptyCheck", typeof(int), "ValueToSort is Null OR ValueToSort = ''");
    
    // apply sort expression
    ActualDataTable.DefaultView.Sort = "NullEmptyCheck asc, ColumnNameToSort asc";
    // pass datasource to grid
    MyGridView.DataSource = ActualDataTable.DefaultView;
    MyGridView.DataBind();

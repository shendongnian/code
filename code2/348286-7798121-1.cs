    private void MyDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        MyDataObjectClass dataContext = (e.Row.DataContext as MyDataObjectClass);
    
        foreach (DataGridColumn col in from cols in MyDataGrid.Columns orderby cols.DisplayIndex select cols)
        {
            FrameworkElement fe = col.GetCellContent(e.Row);
    
            DataGridCell result = fe.Parent as DataGridCell;
    
            // as an example, find a template column w/ a desired sort member path
            if (col is DataGridTemplateColumn && col.SortMemberPath == "x")
            {
                if (condition1)
                {
                    result.ContentTemplate = (DataTemplate)Resources["NestedGridTemplate1"];
                }
                else 
                {
                    result.ContentTemplate = (DataTemplate)Resources["NestedGridTemplate2"];
                }                   
            }
        }
    }

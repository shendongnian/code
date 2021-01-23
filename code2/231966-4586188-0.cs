    private Double GetGridWidth(DataGrid grid)
    {
        Double width = 0.0;
        foreach (DataGridColumn column in myDataGrid.Columns)
        {
            width += column.ActualWidth;
        }
    
        return width;
    }

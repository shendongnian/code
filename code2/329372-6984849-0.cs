    public static DataTable DataViewAsDataTable(DataView dv)
    {
        DataTable dt = dv.Table.Clone();
        foreach (DataRowView drv in dv)
           dt.ImportRow(drv.Row);
        return dt;
    }
        
    DataView view = (DataView) dataGrid.ItemsSource;
    DataTable table = DataViewAsDataTable(view)

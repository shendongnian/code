    DataTable myTable
    myTable.Columns.Add("Foo");
    //etc etc
    myTable.Columns.Add("INTERNAL_STATUS",typeof(DataRowState));
    //Attach event handlers to DataTable.RowChanged, DataTable.ColumnChanged, etc
    //I will just show RowChanged here
    
        private void Row_Changed(object sender, DataRowChangeEventArgs e)
            {
                    e.Row["INTERNAL_STATUS"] = e.Row.RowState;
            }
    
    //Now in your XAML you can use the INTERNAL_STATUS in your data trigger

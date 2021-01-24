    private static void TableRowChanged(object sender, DataRowChangeEventArgs e)
    {
    	e.Row.Table.RowChanged -= new DataRowChangeEventHandler(TableRowChanged);
    	e.Row["Pow"]= Math.Pow(Convert.ToInt32(e.Row["One"]),Convert.ToInt32(e.Row["Two"]));
    	e.Row.Table.RowChanged += new DataRowChangeEventHandler(TableRowChanged);
    }

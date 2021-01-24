    var dataTable = new DataTable();
	dataTable.Columns.Add("One");
	dataTable.Columns.Add("Two");
	dataTable.Columns.Add("Three");//
	dataTable.RowChanged += new DataRowChangeEventHandler(TableRowChanged);

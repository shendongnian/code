    var dataTable = new DataTable();
	dataTable.Columns.Add("One");
	dataTable.Columns.Add("Two");
	dataTable.Columns.Add("Pow");//
	dataTable.RowChanged += new DataRowChangeEventHandler(TableRowChanged);

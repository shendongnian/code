    DataTable tbl = new DataTable();
    tbl.Columns.Add(new DataColumn("ID", typeof(Int32)));
    tbl.Columns.Add(new DataColumn("Name", typeof(string)));
    for (Int32 i = 1; i <= 10; i++) {
    	DataRow row = tbl.NewRow();
    	row["ID"] = i;
    	row["Name"] = i + ". row";
    	tbl.Rows.Add(row);
    }
    DataColumn newCol = new DataColumn("NewColumn", typeof(string));
    newCol.AllowDBNull = true;
    tbl.Columns.Add(newCol);
    foreach (DataRow row in tbl.Rows) {
    	row["NewColumn"] = "You DropDownList value";
    }
    //if you don't want to allow null-values'
    newCol.AllowDBNull = false;

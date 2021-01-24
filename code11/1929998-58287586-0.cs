    DataTable dataTable = new DataTable();
    dataTable.Columns.Add(new DataColumn("Id"));
    dataTable.Columns.Add(new DataColumn("Name"));
    list = dataTable.DefaultView;
    ...
    list.Table.Rows.Add(1, "John");
    ...
    list.Table.Columns.Add(new DataColumn("Address"));
    list.Table.Rows[dataTable.Rows.Count - 1]["Address"] = "address...";

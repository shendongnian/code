    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("Name", typeof(string)));
    dt.Columns.Add(new DataColumn("Value", typeof(KeyValuePair<string, string>)));
    DataRow dRow = dt.NewRow();
    dRow["Name"] = "Eric";
    dRow["Value"] = new KeyValuePair<string, string>("1", "Eric");
    dt.Rows.Add(dRow);

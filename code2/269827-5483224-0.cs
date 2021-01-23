    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("ID", typeof(decimal)));
    dt.Columns.Add(new DataColumn("SUM-ID", typeof(decimal), "ID + ID"));
    var row = dt.NewRow();
    row["ID"] = 2;
    dt.Rows.Add(row);
    var val = dt.Rows[0]["SUM-ID"];

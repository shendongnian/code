    DataTable tbl = new DataTable();
    tbl.Columns.Add("ID", typeof (Int32));
    tbl.Columns.Add("NameID", typeof (Int32));
    tbl.Columns.Add("Name", typeof (String));
    
    tbl.Rows.Add(new object[] { 1, 1, "qwe" });
    tbl.Rows.Add(new object[] { 2, 2, "ert" });
    tbl.Rows.Add(new object[] { 3, 2, "ert" });
    tbl.Rows.Add(new object[] { 4, 3, "dffg" });
    tbl.Rows.Add(new object[] { 5, 3, "dffg" });

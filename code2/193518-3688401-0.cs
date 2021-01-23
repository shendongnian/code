    var dt = new DataTable();
    dt.Columns.Add(new DataColumn("Source", typeof(string)));
    dt.Columns.Add(new DataColumn("Destination", typeof(string)));
    dt.Columns.Add(new DataColumn("Result", typeof(string)));
    dt.Columns.Add(new DataColumn("Timestamp", typeof(DateTime)));
    
    var dr = dt.NewRow();
    dr["Source"] = "DATA";
    dr["Destination"] = "DATA";
    dr["Result"] = "DATA";
    dr["Timestamp"] = DateTime.Now;
    dt.Rows.Add(dr);

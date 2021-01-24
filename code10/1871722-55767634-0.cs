    var conn = new OracleConnection("Data Source=server:1521/sid;password=pwd;user id=usr");
    conn.Open();
    var tbl = conn.GetSchema();
    conn.Close();
    Consile.WriteLine(tbl.Rows.Count.ToString());

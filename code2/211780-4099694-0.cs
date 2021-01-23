    var ds = new DataSet();
 
    using(var conn = new SqlConnection(connString)
    {
        conn.Open();
        var command = new SqlCommand(InitializeQuery(), conn);
        var adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
    }

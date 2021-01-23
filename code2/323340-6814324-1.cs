    var filename = @"c:\work\test.csv";
    var connString = string.Format(
        @"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;FMT=Delimited""", 
        Path.GetDirectoryName(filename)
    );
    using (var conn = new OleDbConnection(connString))
    {
        conn.Open();
        var query = "SELECT * FROM [" + Path.GetFileName(filename) + "]";
        using (var adapter = new OleDbDataAdapter(query, conn))
        {
            var ds = new DataSet("CSV File");
            adapter.Fill(ds);
        }
    }

    using (SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=EffectCatalogue;Data Source=.\\SQLEXPRESS;"))
    {
        conn.Open();
        Stopwatch watch = Stopwatch.StartNew();
                    
        string csvConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\data\\;Extended Properties='text;'";
        OleDbDataAdapter oleda = new OleDbDataAdapter("SELECT * FROM [test.csv]", csvConnString);
        DataTable dt = new DataTable();
        oleda.Fill(dt);
    
        using (SqlBulkCopy copy = new SqlBulkCopy(conn))
        {
            copy.ColumnMappings.Add(0, 1);
            copy.ColumnMappings.Add(1, 2);
            copy.DestinationTableName = "dbo.Users";
            copy.WriteToServer(dt);
        }
        Console.WriteLine("SqlBulkCopy: {0}", watch.Elapsed);
    }

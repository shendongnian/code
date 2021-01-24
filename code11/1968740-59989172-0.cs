    string connectionString =
          @"Provider=Microsoft.ACE.OLEDB.12.0;"
        + @"Data Source=C:\Users\Public\so59983979.accdb";
    using (var con = new OleDbConnection(connectionString))
    {
        con.Open();
        using (var cmd = new OleDbCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = "append_my_table";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var sw = new Stopwatch();
            sw.Start();
            int rowCount = cmd.ExecuteNonQuery();
            sw.Stop();
            Console.WriteLine($"{rowCount} rows inserted in {sw.ElapsedMilliseconds} ms.");
            // 10000 rows inserted in 1014 ms.
        }
    }

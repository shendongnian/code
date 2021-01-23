    using (var conn = new SqlConnection("..."))
    {
    	conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            const string query = @"
                CREATE TABLE #temp 
                    ([ID] INT NOT NULL, [Name] VARCHAR(20) NOT NULL)
                INSERT INTO #temp VALUES(1, 'User 1')
                INSERT INTO #temp VALUES(2, 'User 2')";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
    
            cmd.CommandText = "SELECT * FROM #temp";
            using (var sda = new SqlDataAdapter(cmd))
            {
                var ds = new DataSet();
                sda.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                    Console.WriteLine("{0} - {1}", row["ID"], row["Name"]);
            }
    	}
    }

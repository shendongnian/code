    using (var conn = new SqlConnection("..."))
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            const string query = @"
                CREATE TABLE #temp 
                    ([ID] INT NOT NULL, [Name] VARCHAR(20) NOT NULL)
                INSERT INTO #temp VALUES(1, @username1)
                INSERT INTO #temp VALUES(2, @username2)
                SELECT * FROM #temp
            ";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Parameters.Add("@username1", SqlDbType.VarChar).Value ="First User";
            cmd.Parameters.Add("@username2", SqlDbType.VarChar).Value ="Second User";
            using (var sda = new SqlDataAdapter(cmd))
            {
                var ds = new DataSet();
                sda.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                    Console.WriteLine("{0} - {1}", row["ID"], row["Name"]);
            }
        }
    }

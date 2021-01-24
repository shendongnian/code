            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("One", Test.One, DbType.String, ParameterDirection.Input);
            parameters.Add("Two", Test.Two, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString))
            {
                con.Execute("INSERT INTO test VALUES (@One, @Two)", parameters);
            }

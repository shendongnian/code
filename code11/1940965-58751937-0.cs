    using (IDbConnection conn = new SnowflakeDbConnection())
    {
        conn.ConnectionString = connectionString;
        conn.Open();
    
        IDbCommand cmd = conn.CreateCommand();
        cmd.CommandText = "insert into TestDemo select parse_json(?)";
        IDataReader reader = cmd.ExecuteReader();
                      
        var p1 = cmd.CreateParameter();
        p1.ParameterName = "1";
        p1.Value = "{""student"": ""John Smith""}";
        p1.DbType = DbType.String;
        cmd.Parameters.Add(p1);
        var count = cmd.ExecuteNonQuery();
        Assert.AreEqual(1, count);             
    
        conn.Close();
    }

    using (IDbConnection conn = new SnowflakeDbConnection())
        {
            conn.ConnectionString = connectionString;
            conn.Open();
        
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into t values (?),(?),(?)";
            IDataReader reader = cmd.ExecuteReader();
                          
            var p1 = cmd.CreateParameter();
            p1.ParameterName = "1";
            p1.Value = 10;
            p1.DbType = DbType.Int32;
            cmd.Parameters.Add(p1);
        
            var p2 = cmd.CreateParameter();
            p2.ParameterName = "2";
            p2.Value = 10000L;
            p2.DbType = DbType.Int32;
            cmd.Parameters.Add(p2);
        
            var p3 = cmd.CreateParameter();
            p3.ParameterName = "3";
            p3.Value = (short)1;
            p3.DbType = DbType.Int16;
            cmd.Parameters.Add(p3);
        
            var count = cmd.ExecuteNonQuery();
            Assert.AreEqual(3, count);             
            
            conn.Close();
        }

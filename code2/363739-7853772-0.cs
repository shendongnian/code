    using (OracleConnection conn = new OracleConnection(connectionstring))
    {
        conn.Open();
        using (OracleCommand cmd = new OracleCommand(sql, conn))
        {
            cmd.BindByName = true;
    
            using (OracleParameter param1 = new OracleParameter("p1", OracleDbType.Int32, System.Data.ParameterDirection.Input))
            using (OracleParameter param2 = new OracleParameter("p2", OracleDbType.Varchar2, System.Data.ParameterDirection.Input))
            {
                param1.Value = int.Parse(value1);
                cmd.Parameters.Add(param1);
                param2.Value = value2;
                cmd.Parameters.Add(param2);
    
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    // loop data here...
                }
            }
        }
    }

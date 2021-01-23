    OracleParameter param1 = new OracleParameter("p1", OracleDbType.Int32, System.Data.ParameterDirection.Input);
                
    param1.Value = int.Parse(value1);
    cmd.Parameters.Add(param1);
                
        
    OracleParameter param2 = new OracleParameter("p2", OracleDbType.Varchar2, System.Data.ParameterDirection.Input);
       
    param2.Value = value2;
    cmd.Parameters.Add(param2);
                
        
    using (OracleDataReader dr = cmd.ExecuteReader())
    {
      // loop data here...
    }
        
    param1.dispose();
    param2.dispose();

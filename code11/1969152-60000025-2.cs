       ...
    
       using (OracleCommand cmd = connection.CreateCommand()) {
         cmd.CommandText = 
           @"INSERT INTO CUSTOMERS (
               NAME,
               DETAILS) 
             VALUES (
               :nm, 
               :dts)
             RETURNING 
               ""ORDER"" INTO :orderid";
    
         cmd.Parameters.Add("nm", OracleDbType.VarChar);
         cmd.Parameters["nm"].Value = name;
         cmd.Parameters.Add("dts", OracleDbType.VarChar);
         cmd.Parameters["dts"].Value = details;
    
         cmd.Parameters.Add("orderid", OracleDbType.VarChar);  
         cmd.Parameters["orderid"].Direction = ParameterDirection.Output;
           
         try {
           cmd.ExecuteNonQuery(); // Just execute, nothing to read
           transaction.Commit(); 
    
           guid = Convert.ToString(cmd.Parameters["orderid"].Value);
         }
         catch (Exception e) { //TODO: put more specific exception type
           transaction.Rollback();   
           Console.WriteLine(e.Message);     
         } 
    
         return guid;
       }  
    
       ...

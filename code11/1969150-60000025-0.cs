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
         cmd.Parameters["dts"].Direction = ParameterDirection.Output;
           
         try {
           cmd.ExecuteNonQuery();
           transaction.Commit(); 
    
           guid = Convert.ToString(cmd.Parameters["dts"].Value);
         }
         catch (Exception e) {
           transaction.Rollback();   
           Console.WriteLine(e.Message);     
         } 
    
         return guid;
       }  
    
       ...

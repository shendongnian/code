    static void Main(string[] args)
    {
      // Connect
      string connectStr = getConnection();
    
      // Setup the Tables for sample
    
      OracleConnection connection = new OracleConnection(connectStr);
      OracleCommand cmd = new OracleCommand("MyTestAssociativeArray.TestVarchar2", connection);
      cmd.CommandType = CommandType.StoredProcedure ;
      
      OracleParameter param1 = cmd.Parameters.Add("param1", OracleDbType.Varchar2);
      OracleParameter param2 = cmd.Parameters.Add("param2", OracleDbType.Varchar2);
    
      // Setup the direction
      param1.Direction = ParameterDirection.Input;
      param2.Direction = ParameterDirection.Input;
    
      // Specify that we are binding PL/SQL Associative Array
      param2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    
      param1.Value = "ConstantValue" ;
      param2.Value = new string[3]{"Val1",
                                   "Val2",
                                   "Val3"};
     
    
      try 
      {
        connection.Open();
        cmd.ExecuteNonQuery();
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    
    }

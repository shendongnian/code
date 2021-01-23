    using System;
    using System.Data;
    using Oracle.DataAccess.Client;
    
    ...
    
    // Create the connection object
    OracleConnection con = new OracleConnection();
      
    // Specify the connect string
    // NOTE: Modify User Id, Password, Data Source as per your database set up
    con.ConnectionString = "User Id=userid;Password=password;Data Source=dbinstance;";
    
    try
    {
      // Open the connection
      con.Open();
      Console.WriteLine("Connection to Oracle database established!");
      Console.WriteLine(" ");
    } 
    catch (Exception ex)
    {
     Console.WriteLine(ex.Message);
    }
    
    string cmdQuery = "SELECT empno, ename FROM emptab";
         
    // Create the OracleCommand object
    OracleCommand cmd = new OracleCommand(cmdQuery);
    cmd.Connection = con;
    cmd.CommandType = CommandType.Text;
    
    try
    {
      // Execute command, create OracleDataReader object
      OracleDataReader reader = cmd.ExecuteReader();
      while (reader.Read())
      {
        // Output Employee Name and Number
        Console.WriteLine("Employee Number: " + 
                        reader.GetDecimal(0) + 
                                        " , " +
                           "Employee Name : " +
    
    
                          reader.GetString(1));
      }
    }
    catch (Exception ex) 
    {
      Console.WriteLine(ex.Message);
    } 
    finally
    {
      // Dispose OracleCommand object
      cmd.Dispose();
    
    
      // Close and Dispose OracleConnection object
      con.Close();
      con.Dispose(); 
    }

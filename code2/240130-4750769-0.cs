    using System.Data.SqlClient;
    
    // trusted connection (SQL configured to use your windows ID)
    string ConnectionString = 
      "Data Source=xxxxxxx;Initial Catalog=xxxxxx;Integrated Security=SSPI;"
    // sql authentication (SQL manages its own users/pwds)
    //string ConnectionString = 
      //"Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;"
    var conn = new SqlConnection(ConnectionString);
    conn.Open();
    
    var strSQLCommand = "SELECT Name from [example_autoincrement] where id='1'";     
    var command = new SqlCommand(strSQLCommand, conn);
    var reader = command.ExecuteReader();
    
    while (reader.Read())
    {   
        passwordBox.Text = reader.GetString(0);
    }
    
    reader.Close();
    conn.Close();

    SqlConnection conn = new SqlConnection("Data Source=serverName;"
               + "Initial Catalog=databaseName;"
               + "Persist Security Info=True;"
               + "User ID=userName;Password=password");
 
    conn.Open();
 
    // create a SqlCommand object for this connection
    SqlCommand command = conn.CreateCommand();
    command.CommandText = "Select * from tableName";
    command.CommandType = CommandType.Text;
 
    // execute the command that returns a SqlDataReader
    SqlDataReader reader = command.ExecuteReader();
 
    // display the results
    while (reader.Read()) {
        //whatever you want to do.
    }
 
    // close the connection
    reader.Close();
    conn.Close();

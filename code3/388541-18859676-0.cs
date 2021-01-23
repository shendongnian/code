    MySqlConnection connection = new MySqlConnection(ConnectionString);
    connection.Open();
    int res = MySqlHelper.ExecuteNonQuery(
    	connection,
    	"INSERT INTO games (col1,col2) VALUES (1,2);");
    
    object ores = MySqlHelper.ExecuteScalar(
    connection,
    "SELECT LAST_INSERT_ID();");
    
    if (ores != null)
    {
      // Odd, I got ulong here.
      ulong qkwl = (ulong)ores;
      int Id = (int)qkwl;
    }

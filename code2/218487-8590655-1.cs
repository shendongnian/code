    SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbSQLite + ";Read Only=False;");
    connection.Open();
    SQLiteCommand mycommand = new SQLiteCommand(connection);
    mycommand.CommandText = "PRAGMA foreign_keys=ON";
    mycommand.ExecuteNonQuery();
    mycommand.CommandText = "DELETE FROM table WHERE ID=x";
    mycommand.ExecuteReader();
    connection.Close();

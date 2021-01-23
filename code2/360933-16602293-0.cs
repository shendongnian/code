    string myConnectionString = "SERVER=localhost;UID='root';" + "PASSWORD='root';";
    MySqlConnection connection = new MySqlConnection(myConnectionString);
    MySqlCommand command = connection.CreateCommand();
    command.CommandText = "SHOW DATABASES;";
    MySqlDataReader Reader;
    connection.Open();
    Reader = command.ExecuteReader();
    while (Reader.Read())
    {
      string row = "";
      for (int i = 0; i < Reader.FieldCount; i++)
           row += Reader.GetValue(i).ToString() + ", ";
           comboBox1.Items.Add(row);
    }
    connection.Close();

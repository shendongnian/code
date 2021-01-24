    MySqlCommand command = new MySqlCommand();
    String editQuery = "sql query";
    command.CommandText = editQuery;
    command.Connection = conn.getConnection();
    command.Parameters.Add("@pic", MySqlDbType.Blob).Value = picture.ToArray();

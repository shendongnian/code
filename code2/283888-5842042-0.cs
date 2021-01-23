    string content = "SELECT title FROM content";
    MySqlCommand contentCommand = new MySqlCommand(content, sqlConn);
    try
    {
        sqlConn.Open();
        sqlReader = contentCommand.ExecuteReader();
        while (sqlReader.Read())
        {
            cont = sqlReader.GetValue(0).ToString();
            cntpaginaBX.Items.Add(cont);
        }
        sqlReader.Close();
    }

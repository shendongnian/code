    public void CreateMySqlDataReader(string mySelectQuery, MySqlConnection myConnection)
    {
    MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
    myConnection.Open();
    MMySqlDataReader myReader;
    myReader = myCommand.ExecuteReader();
    try
    {
    while(myReader.Read())
    {
    Console.WriteLine(myReader.GetString(0));
    }
    }
    finally
    {
    myReader.Close();
    myConnection.Close();
    }
    }

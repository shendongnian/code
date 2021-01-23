    string JSON_string = JsonConvert.SerializeObject(SomeObject);
    System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
    myCommand.Parameters.AddWithValue("", SomeAttribute);
    myCommand.Parameters.AddWithValue("", SomeAttribute2);
    myCommand.Parameters.AddWithValue("", SomeAttribute3);
    myCommand.Parameters.AddWithValue("", JSON_string);

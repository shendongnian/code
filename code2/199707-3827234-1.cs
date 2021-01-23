    OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=YourDatabase.accdb");
    OleDbCommand command = connection.CreateCommand();
    command.CommandText = "SELECT ColumnWithTypeText FROM TableName";
    
    connection.Open();
    
    OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
    
    if (reader.HasRows)
    {
        if (reader.Read())
        {
            textBox1.Text = reader["ColumnWithTypeText"].ToString();
            //textBox1.Text = reader.GetString(0);
        }
    }
    else
    {
        textBox1.Text = "No rows found!";
    }
    
    reader.Close();
    connection.Close();

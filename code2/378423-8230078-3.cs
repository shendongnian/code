    string statement = "INSERT INTO mytable(mycolumn) VALUES (@text)";
    SqlCommand command = new SqlCommand(statement);
    command.Parameters.AddWithValue("@text", myTextBox.Text);
    try{
        SqlConnection connection = new SqlConnection(myConnectionString);
        connection.Open();
        command.Connection = connection;
        command.ExecuteNonQuery();
    } catch {
        //do exception handling stuff
    }

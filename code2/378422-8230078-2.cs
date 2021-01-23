    string statement = "INSERT INTO mytable(mycolumn) VALUES (@text)";
    using(SqlCommand command = new SqlCommand(statement)
    using(SqlConnection connection = new SqlConnection(myConnectionString) {
        try{
            command.Parameters.AddWithValue("@text", myTextBox.Text);
            connection.Open();
            command.Connection = connection;
            command.ExecuteNonQuery();
        } catch {
            //do exception handling stuff
       }
    }

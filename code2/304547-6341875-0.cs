    using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "SELECT ColumnName FROM [check]";
        connection.Open();
        while (myReader.Read())
            TextBox1.Text = reader["ColumnName"].ToString();
    }

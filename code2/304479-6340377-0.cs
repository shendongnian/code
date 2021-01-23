    string query = null;
    using (var command = new SqlCommand(""select query from Table1 where syntax = @Syntax", conn))
    {
        command.Parameters.AddWithValue("@Syntax", textBox1.Text);
        query = command.ExecuteScalar(); // this assumes only one query result is returned
    }

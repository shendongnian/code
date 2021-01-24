    var connectionString = "";
    var sql = @"SELECT TOP 1 Name, Member_Id, Status
                FROM Test_Employee 
                WHERE Name LIKE @name + '%'";
    
    using (var connection = new SqlConnection(connectionString))
    using (var command = new SqlCommand(sql, connection))
    {
        command.Parameters.Add("name", SqlDbType.NVarChar, 100).Value = textBox1.Text.ToString();
        connection.Open();
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            textBox9.Text = dataReader["Name"].ToString();
            textBox7.Text = dataReader["Name"].ToString();
            textBox2.Text = dataReader["Member_Id"].ToString();
            textBox3.Text = dataReader["Status"].ToString();
    
        }
    }

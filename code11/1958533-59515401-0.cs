    string connectionString = "server=myServer;User ID=myUser;Password=myPwd;"; // could also be internal static on class level
    
    string theQuery = "SELECT * FROM dbo.Users WHERE Username = @userName AND Password = @password";
    
    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    {
        sqlConnection.Open();
    
        using (SqlCommand sqlCommand = new SqlCommand(theQuery, sqlConnection))
        {
            sqlCommand.Parameters.AddWithValue("@userName", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@password", textBox2.Text);
    
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlCommand.ExecuteReader());
            if (dataTable.Rows > 0)
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.Fill(dataTable);
            }
        }
    }

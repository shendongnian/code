    string queryString = 
        @"
    CREATE TABLE MyTable
    (
       Id  int IDENTITY(1,1) PRIMARY KEY CLUSTERED,
       Name        varchar(50) 
    )";
    using (SqlConnection connection = new SqlConnection(
               myConnectionString ))
    {
        SqlCommand command = new SqlCommand(
            queryString, connection);
        connection.Open();
        command.ExecuteNonReader();
        command.CommandText = @"Insert INTO MyTable Values ('Abe')";
        command.ExecuteNonReader();
    }

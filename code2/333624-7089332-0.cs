    using(SqlConnection connection = new SqlConnection(ConnectionString)){
    {
        using(SqlCommand command = new SqlCommand(commandText, connection)){
            //your code here
        }
    }

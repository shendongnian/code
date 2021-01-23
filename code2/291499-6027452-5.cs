    DataTable dataTable = new DataTable();
    using(SqlConnection connection = new SqlConnection("Server=localhost;Database=Timer;Trusted_Connection=True"))
    using(SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = "select * from Timer";
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        dataTable.Load(reader);
    }

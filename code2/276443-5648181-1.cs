    string connectionString = "...";
    DataTable tables = new DataTable("Tables");
    using (SqlConnection connection =
           new SqlConnection(connectionString))
    {
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "select table_name as Name from
                  INFORMATION_SCHEMA.Tables where TABLE_TYPE =
                  'BASE TABLE'";
        connection.Open();
        tables.Load(command.ExecuteReader(
                        CommandBehavior.CloseConnection));
    }

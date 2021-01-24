    public IEnumerable<Employee> GetEmployees()
    {
        string connectionString = "CONNECTION STRING";
        string commandText = "COMMAND TEXT";
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new MySqlCommand(commandText, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Employee()
                        {
                            FirstName = reader.GetFieldValue<string>(0),
                            LastName = reader.GetFieldValue<string>(1)
                        };
                    }
                }
            }
        }
    }

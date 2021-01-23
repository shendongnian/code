    using(var connection = new SqlConnection(connectionString)) {
        connection.Open();
        using(var command = connection.CreateCommand()) {
            command.CommandText = "SELECT * FROM SYS.TABLES";
            using(var reader = command.ExecuteReader()) {
                while(reader.Read()) {
                    Console.WriteLine(reader["name"]);
                }
            }
        }
    }

    var connectionString = @"Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;";
    using (var conn = new SqlConnection(connectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT Name FROM Customers";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                var customerName = reader.GetString(reader.GetOrdinal("Name"));
                Console.WriteLine(customerName);
            }
        }
    }

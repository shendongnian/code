    class Program
    {
        static void Main()
        {
            var connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\work\DataBase.mdb";
            using (var conn = new OleDbConnection(connectionString))
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
        }
    }

    class Program
    {
        static void Main()
        {
            using (var conn = new SQLiteConnection("Data Source=http_stackoverflow.com_0.localstorage;Version=3;"))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM ItemTable";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("key: {0}, value: {1}", reader.GetString(0), reader.GetString(1));
                    }
                }
            }
        }
    }

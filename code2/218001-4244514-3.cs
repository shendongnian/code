    public class MySQLRepository: IRepository
    {
        public IEnumerable<Item> GetItems()
        {
            using (var conn = new MySqlConnection("SOME CONNECTION STRING"))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open(); 
                cmd.CommandText = "SELECT id, name FROM items;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Item
                        {
                            Id = reader.GetString(0),
                            Label = reader.GetString(1),
                        };
                    }
                }
            }
        }
    }

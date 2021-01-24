            var customers = new List<Customer>(); // get your customers
            
            using (var conn = new SQLiteConnection("your connection string"))
            {
                await conn.OpenAsync();
                using (var cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = cmd.CommandText = "INSERT INTO CUSTOMER (Phone, FirstName) VALUES(@param1, @param2)";
                    cmd.CommandType = CommandType.Text;
                    using (var trans = conn.BeginTransaction())
                    {
                        foreach (var c in customers)
                        {
                            cmd.Parameters.AddWithValue("@param1", c.Phone);
                            cmd.Parameters.AddWithValue("@param2", c.FirstName);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }
            }

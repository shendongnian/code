            using (var conn = GetSqlConnection())
            {
                var param1 = "This is a parameter";
                var param2 = "04/23/2019";
                var param3 = 2;
                using (var comm = GenerateSqlCommand("SELECT * FROM Users WHERE Username = @Username and Date = @Date and Id = @Id", param1, param2, param3))
                    {
                    comm.Connection = conn;
                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // TODO: handle the results
                            reader.GetString(0);
                            reader.GetInt32(1);
                        }
                    }
                }
            }

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT OBJECT_ID('" + MyObjectName + @"')";
                if (cmd.ExecuteScalar() == DBNull.Value)
                {
                    Console.WriteLine("Does not exist");
                }
                else 
                {
                    Console.WriteLine("Does exist");
                }
            }

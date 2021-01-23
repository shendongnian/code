    using (SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Orders", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(2));
                        }
                    }
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM Products", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(1));
                        }
                    }
                }
            }

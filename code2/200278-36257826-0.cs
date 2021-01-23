    `using (SqlConnection connection = new SqlConnection("your connection string"))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * from SomeTable";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // read here
                    }
                }
            }`

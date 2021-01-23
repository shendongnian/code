        public void SomeMethod()
        {
            using (var conn = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI"))
            {
                conn.Open();
                using (var cmd = new SqlCommand("select * from Customers", conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0]);
                    }
                }
            }
        }

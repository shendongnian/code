        public void SomeMethod()
        {
            using (var conn = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI"))
            {
                conn.Open();
                using (var cmd = new SqlCommand("select * from Customers", conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    var builder = new StringBuilder();
                    while (rdr.Read())
                    {
                        builder.Append(rdr[0]).Append(Environment.NewLine);
                    }
                    // assuming you are on the main thread here, if you're calling
                    // from a parallel thread you spawned, you'd need to check if
                    // invoke required, lot's of SO answers on how-to, etc if so.
                    _resultsText.Text = builder.ToString();
                }
            }
        }

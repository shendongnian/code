       public class SqlConnectionDemo
        {
            // NEED METHOD DECLARATION HERE
            public void SomeMethod()
            {
                SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");
    
                SqlDataReader rdr = null;
                try
                {
    
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from Customers", conn);
                    rdr = cmd.ExecuteReader();
    
    
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0]);
                    }
                }
                finally
                {
                    // close the reader
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
    
                    // 5. Close the connection
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }

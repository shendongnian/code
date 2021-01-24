    Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();
        string prm = "\"" + name + "\"";  // Doublequote a string
    
          //execute method
          CheckCustomer(prm);
    
    
    
        private static string CheckCustomer(string cusName)
        {
            string cust = "null";
    
            try
            {
                Console.WriteLine("\nChecking custoemr...\n");
                // Sql Select Query
                string sql = "SELECT * FROM Customer WHERE CustomerName = @CusName";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@CusName", cusName);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
    
                string strCusname = "Customer Name Found";
                Console.WriteLine("{0}", strCusname.PadRight(25));
                Console.WriteLine("==============================");
    
                while (dr.Read())
                {
                    ////reading from the datareader
    
                   cust = dr["CustomerName"].ToString();
    
                }
                dr.Close();
                return cust;
    
            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
                return null;
            }
        }
    
    try this.

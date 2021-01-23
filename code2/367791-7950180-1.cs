    using (SqlConnection conn1 = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI"))
    { 
        using (conn1.BeginTransaction()
        {
            try
            {
                FirstMethod(Conn1);
                SecondMethod(Conn2);
            }
            catch()
            {
            }
        }
    }

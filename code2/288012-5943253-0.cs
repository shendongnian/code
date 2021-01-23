    string connString = @"Data Source=KIMMY-MSI\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
    string sql = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
    using (SqlConnection conn = new SqlConnection(connString))
    using (SqlCommand comm = new SqlCommand(sql, conn))
    {
    	comm.Connection.Open();
    	comm.Parameters.AddWithValue("@CustomerID", txtID.Text);
    	using (SqlDataReader dReader = comm.ExecuteReader())
    	{
    		if (dReader.HasRows == true)
    		{
    			Response.Write("Exists");
    		}	
    	}
    }

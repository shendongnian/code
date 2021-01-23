        // Assumes that connection is a valid SqlConnection object.
    string queryString = "SELECT CustomerID, CompanyName FROM dbo.Customers";
    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
    DataSet customers = new DataSet();
    adapter.Fill(customers, "Customers");
    DataTable table = customers.Tables[0];

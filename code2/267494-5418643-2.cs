    ConnectionStringSettings connection = uiConnection.SelectedItem as ConnectionStringSettings
    string queryString = "SELECT CustomerID, CompanyName FROM dbo.Customers";
    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
    DataSet customers = new DataSet();
    adapter.Fill(customers, "Customers");

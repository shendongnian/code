    string queryString =
        "SELECT OrderID, CustomerID FROM dbo.Orders;";
    using (SqlConnection connection =
               new SqlConnection(connectionString))
    {
        SqlCommand command =
            new SqlCommand(queryString, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        // Call Read before accessing data.
        while (reader.Read())
        {
           CustomersRow newCustomersRow = Customers.NewCustomersRow();
           newCustomersRow.CustomerID = reader[0].ToString();
           newCustomersRow.CompanyName = reader[1].ToString();
           dt.Rows.Add(newCustomersRow);
        }
        // Call Close when done reading.
        reader.Close();
    }
}

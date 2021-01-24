    private void DoFilter()
    {
        using (connection = new SqlConnection(connectionString))
        using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customers WHERE CompanyName LIKE @filter + '%'", connection))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@filter", txtFilter.Text.Trim());
            DataTable TCustomers = new DataTable();
            adapter.Fill(TCustomers);
            lstCustomers.DisplayMember = "CompanyName";
            lstCustomers.ValueMember = "Id";
            lstCustomers.DataSource = TCustomers;
        }
    }

    DataTable dataTable = new DataTable();
    string connectionString = "server = (local); initial Catalog = SQLTraining; Integrated Security = SSPI";
    string selectCommandText = String.Format("SELECT {0} FROM {1}",
        attribute_name,
        tablename);
    using (SqlConnection selectConnection = new SqlConnection(connectionString))
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection))
        {
            adapter.Fill(dataTable);
        }
    }
    gridView.DataSource = dataTable;
    gridView.DataBind();

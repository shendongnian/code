    SqlConnection dataConnection = new SqlConnection();
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
    builder.DataSource = ".\\SQLExpress"; // Your Datasource
    builder.InitialCatalog = "Northwind"; // Database Name
    builder.IntegratedSecurity = true;
    dataConnection.ConnectionString = builder.ConnectionString;
    dataConnection.Open();

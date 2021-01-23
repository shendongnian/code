    SqlConnection dataConnection = new SqlConnection();
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
    builder.DataSource = "YourSeverName";
    builder.InitialCatalog = "YourDatabase";
    builder.IntegratedSecurity = true;
    dataConnection.ConnectionString = builder.ConnectionString;

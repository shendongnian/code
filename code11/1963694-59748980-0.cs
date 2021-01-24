    SqlConnection myConnection = new SqlConnection();
    SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();
    myBuilder.IntegratedSecurity = true;
    myBuilder.InitialCatalog = "BikeStores";
    myBuilder.DataSource = "NBE\\SQLEXPRESS";
    myConnection.ConnectionString = myBuilder.ConnectionString;

    string MyDBConnection = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(MyDBConnection);
    string UserID = builder.UserID;
    string Password = builder.Password;
    string ServerName = builder.DataSource;
    string DatabaseName = builder.InitialCatalog;

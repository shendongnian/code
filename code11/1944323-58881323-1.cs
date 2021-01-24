    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder ()
        {
            DataSource = "ServerName",
            InitialCatalog = "DatabaseName",
            etc...
        }
    
    builder.Authentication = SqlAuthenticationMethod.ActiveDirectoryInteractive;
    SqlConnection sqlConnection = new SqlConnection(builder.ConnectionString);

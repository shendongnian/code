    SqlConnection conn = new SqlConnection(
        new SqlConnectionStringBuilder ()
        {
            DataSource = "dvzxfsdg-sql.database.windows.net",
            InitialCatalog = "dfsdfs-sqldb",
            UserID = "UserName",
            Password = "UserPassword"
        }.ConnectionString
    );

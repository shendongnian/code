    if (db != null)
    {
        SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder(db.ConnectionString)
       { ConnectTimeout = 5, InitialCatalog = "your CatalogName" }; // you can add other parameters.
          db.ConnectionString = conn.ConnectionString;
          db.Open();
          return true;
       }
    }

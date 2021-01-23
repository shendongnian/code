     connectionBuilder = new SqlConnectionStringBuilder(sqlConnection.ConnectionString)
                    {
                        InitialCatalog = "master",
                        AttachDBFilename = string.Empty, 
                    };

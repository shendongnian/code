                var connString = ConfigurationManager.ConnectionStrings["MyDataEntities"].ConnectionString;
                EntityConnection ec = new EntityConnection(connString);
                var storeConnect = ec.StoreConnection;
    
                SqlDataSource1.ConnectionString = storeConnect.ConnectionString;

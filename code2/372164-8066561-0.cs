    protected override AdventureWorksEntities CreateDataSource()
        {
            EntityConnection entityConnection = new EntityConnection();
            entityConnection.ConnectionString = "ConnectionStringConnecting to the  databaseName";
            //set other proeprties on the entityConnection
            AdventureWorksEntities dataContext = new AdventureWorksEntities(entityConnection);
            return dataContext;
         }

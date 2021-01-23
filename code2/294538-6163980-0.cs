    DbConnection sqlCeConnection = System.Data.SqlServerCe.SqlCeProviderFactory.Instance.CreateConnection();
    sqlCeConnection.ConnectionString = "|DataDirectory|\DogDatabase.sdf";
    using (DogContext dogContext = new DogContext(sqlCeConnection, true))
    {
        var annoyingDogs = dogContext.Dogs.Where(d => d.BarkAnnoyanceLevel == BarkAnnoyanceLevels.High);
        // Do stuff...
    }

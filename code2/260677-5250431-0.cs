     public class DataFactory
    {
        public enum DataStores
        { 
            ReadOnly=1,
            ReadWrite=2,
            ReadWriteProTest=3
            
        }
        public static string GetConnectionString(DataStores dataStore)
        {
            Database currentDatabase = null;
            switch (dataStore)
            {
                case (DataStores.ReadOnly):
                    currentDatabase = DatabaseFactory.CreateDatabase("ReadOnlyDB");
                    break;
                case (DataStores.ReadWrite):
                    currentDatabase = DatabaseFactory.CreateDatabase("ReadWriteDB");
                    break;
                case (DataStores.ReadWriteProTest):
                    currentDatabase = DatabaseFactory.CreateDatabase("ReadWriteProdTest");
                    break;
                default:
                    currentDatabase = DatabaseFactory.CreateDatabase("ReadOnlyDB");
                    break;
            }
            return currentDatabase.ConnectionString;
        }
    }

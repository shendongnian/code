    public static class ProviderFactory
    {
        public static IDataProvider GetProvider()  //I'd pass parameters if I had more than 1.
        {
            Connection connection = new Connection(); //this is why I broke DI.
            IConnection iConnection = (IConnection)connection;
    
            AzureProvider azureProvider = new AzureProvider(iConnection);
            IDataProvider iDataProvider = (IDataProvider)azureProvider;
    
            return iDataProvider;
        }
    }

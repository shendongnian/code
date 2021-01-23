    public class AzureProvider : IDataProvider
    {
        IConnection Connection { get; set; }
    
        public AzureProvider(IConnection connection)
        {
            this.Connection = connection;
        }
    
        public void Foo()
        {
    
        }
    }

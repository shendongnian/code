    public interface IMyContextFactory
    {
        MyContextFactory Get();
    }
    public class MyContextFactory : IMyContextFactory
    {
        private const string OnlineConnectionString = "...";
        private const string OfflineConnectionString = "...";
        private IConnectionManager _connectionManager;
        public MyContextFactory(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        public MyContextFactory Get() 
        {
            var connectionString = _connectionManager.IsOnline() 
                ? OnlineConnectionString 
                : OfflineConnectionString
            return new MyContext(connectionString);
        }
    }
    // DI Bindings, Ninject style
    Bind<IMyContextFactory>().To<MyContextFactory>();
    // Usage
    public class ThingRepository : IThingRepository 
    {
        private IMyContextFactory _myContextFactory;
        public ThingRepository(IMyContextFactory myContextFactory)
        {
            _myContextFactory = myContextFactory;
        }
        public IEnumerable<Something> GetAllThings()
        {
            using(var context = _myContextFactory.Get())
            {
                return context.Things.ToList();
            }
        }
    }

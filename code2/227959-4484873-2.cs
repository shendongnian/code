    public interface IDataController
    {
        DbConnection CreateConnection<TDbConnection>(params string[] args)
            where TDbConnection : DbConnection, IDbConnection;
    }
    [Export(typeof(IDataController))]
    public class DataController : IDataController
    {
        // singleton implementation
        private static volatile Lazy<IDataController> _ControllerInstance = new Lazy<IDataController>(() => new DataController());
        public static IDataController ControllerInstance
        {
            get { return _ControllerInstance.Value; }
        }
        public DbConnection CreateConnection<TDbConnection>(params string[] args) 
            where TDbConnection : DbConnection, IDbConnection
        {
            throw new NotImplementedException();
        }
    }

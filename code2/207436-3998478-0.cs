    public class DoSomethingFacade {
        private static readonly DoSomethingFactory _doSomethingFactory = new DoSomethingFactory();
        public static IList<T> GetList<T>() {
            using(IDbConnection connection = OpenConnection("string..."))
                return _doSomethingFactory.GetList<T>(connection);
        }
        public static IDbConnection OpenConnection(string connectionString) {
            IDbConnection openedConnection = new SqlConnection(connectionString);
            openedConnection.Open();
            return openedConnection;
        }
    }
    internal class DoSomethingFactory {
        internal DoSomethingFactory() { }
        internal IList<T> GetList<T>(IDbConnection connection) {
            IList<T> results = new List<T>();
            // use connection here without caring about it, 
            // as it should be provided as an opened available connection.
            return results;
        }
    }

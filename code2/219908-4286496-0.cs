    public static class SystemFacade {
        // Used as a subsystem to which the connections are provided.
        private static readonly SystemFactory _systemFactory = new SystemFactory();
        public static IList<Customer> GetCustomers() {
            using (var connection = OpenConnection(nameOfEntLibNamedConnection))
                return _systemFactory.GetCustomers(connection);
        }
        public static DbConnection OpenConnection(string connectionName) {
            var connection = 
                // Read EntLib config and create a new connection here, and assure
                // it is opened before you return it.
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;            
        }
    }
    internal class SystemFactory {
        internal IList<Customer> GetCustomers(DbConnection connection) {
            // Place code to get customers here.
        }
    }

    class Connection
    {
        public static Connection Instance() {
            if (_instance == null) {
                lock (typeof(Connection)) {
                    if (_instance == null) {
                        _instance = new Connection();
                    }
                }
            }
            return _instance;      
        }
        protected Connection() {}
        private static volatile Connection _instance = null;
    }

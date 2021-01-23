        public class Repository : IRepository
        {
            private readonly string _connectionString;
            public Repository(string connectionString)
            {
                _connectionString = connectionString;
            }
            public object Read()
            {
               // Do stuff
            }
            public void Write(object o)
            {
               // Do stuff
            }
        }

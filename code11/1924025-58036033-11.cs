    public DL : IDisposable
    {
        private SqlConnection connection = new SqlConnection("...");
        public IEnumerable<T> GetAll<T>() 
        {
             connection.Open();
             //...
        }
  
        public void Dispose()
        {
             if (connection is IDisposable) connection.Dispose();
        }
    }

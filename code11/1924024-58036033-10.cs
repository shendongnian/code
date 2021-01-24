    public DL 
    {
        private SqlConnection connection = new SqlConnection("...");
        public IEnumerable<T> GetAll<T>() 
        {
             connection.Open();
             //...
        }
    }

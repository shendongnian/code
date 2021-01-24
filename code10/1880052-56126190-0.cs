    public MyClass
    {
        private ObjectRepository _objectRepository;
    
        public MyClass(string connString)
        {
            // if your ObjectRepository for example requires a connection string param
            _objectRepository = new ObjectRepository(connString);
        }
    }

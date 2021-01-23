        private IDatabaseConnectionFactory databaseConnectionFactory;
        public SomeClass() : this(new DatabaseConnectionFactory()) { }
        public SomeClass(IDatabaseConnectionFactory factory) 
        {
            databaseConnectionFactory = factory;
        }
        .
        .
        using (var connection = DatabaseConnectionFactory.Create()) { ... }
        .
        .

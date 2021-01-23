        public string ConnectionString { get; set; } // Preciso uma variavel para guardar o ConnectionString
        public IDbConnection Connection { get; set; }
        //public abstract string ProviderName { get; } // Preciso uma variavel para guardar o ConnectionString
        //public abstract IDbConnection CreateConnection(string ConnectionString);
        public abstract IDbConnection CreateConnection(); // Preciso um Metodo Abstract para CreateConnection Para Tratar da Connection
        public abstract IDbCommand CreateCommand();

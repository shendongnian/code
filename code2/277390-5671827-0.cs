      public static class Repository
      {
        static BooksRepository _bookRepository = null;
        static string connectionString;
        public static void ConnectionString(string cs) { connectionString = cs; }
        public static BooksRepository BookRepository(Boolean create)
        {
          if (connectionString == null) 
            throw new ApplicationException("Need to set connection string for Repository");
          if (!create && _bookRepository != null) return _bookRepository;
          else
          {
            _bookRepository = new BooksRepository(connectionString);
            return _bookRepository;
          }
        }
      }
    

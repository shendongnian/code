    public class ErpEntities : IDisposable 
    { 
 
        public int SaveCustomer(string Name, string SurName) 
        {
            using(DataRepository repository = new DataRepository<Customer>(new TestErpEntities()))
            { 
               return repository.Add(new Customer() { Name = Name, SurName = SurName });  
            } // This using statment ensures that the DataRepository is Dispose()'d when the method exits
        } 
 
 
        #region IDisposable Members 
 
        public void Dispose() 
        { 
           // You could eliminate this as there's nothing in your 
           // ErpEntities class that needs disposing
        } 
 
        #endregion 
    } 
    public class DataRepository<T> : IRepository<T> where T : class     
    {     
     
        private TestErpEntities _context;     
     
        public DataRepository()     
        {     
        }     
     
        public DataRepository(TestErpEntities context)     
        {     
            _context = context;     
        }     
     
        public int Add(T entity)     
        {     
            _context.AddObject(typeof(T).Name, entity);     
            int saveValue = _context.SaveChanges();     
            return saveValue;     
        }     
     
     
        public void Dispose()     
        {     
            if (_context != null)     
                _context.Dispose();     
        }
    }  

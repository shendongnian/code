    public class IGenericRepository 
    {
       void Save();
    }
        
    public class GenericRepository : IGenericRepository
    {     
        public myDataContext dc = new myDataContext(); 
        private _IGenericRepository = null;
     
       // bla bla bla
    
        public GenericRepository(IGenericRepository repository)
        {
            _IGenericRepository = repository;
        }
    
        void Save()
        {
           _IGenericRepository.Save();
        }         
    }

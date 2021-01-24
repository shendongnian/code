    public class MyController
    {
        private readonly DbContext _context;
    
        public MyController(DbContext context)
        {
          _context = context;
        }
    
        ...
    } 

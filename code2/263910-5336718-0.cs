    public class Repository
    {
      private readonly DbContext _context;
    
      public Repository(DbContext context)
      {
        _context = context;
      }
      ...
    }
    
    var repository = new Repository(new PlssContext());

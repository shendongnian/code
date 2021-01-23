    private IDbContext _context;
    
    public UnitOfWork(IDbContext context)
    {
        _context = context
    }
    
    private _INewsRepository;
    public INewsRepoitory 
    {
        get{
             if(_INewsRepository == null)
             {
                  _INewsRepository = new NewsREpository(_context);
                  return _INewsRepository;
             }
             else
             {
                  return _INewsRepository;
             }    
    }

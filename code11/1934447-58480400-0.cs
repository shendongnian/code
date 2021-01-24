    private readonly ApplicationDbContext _dbcontext;
    public HomeController( ApplicationDbContext dbContext)
    { 
        this._dbcontext = dbContext;
     
    }

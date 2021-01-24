    public MyController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IActionResult([FromServices] ApplicationDbContext dbContext){
    }

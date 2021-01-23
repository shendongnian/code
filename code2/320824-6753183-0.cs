    public HomeController(IDataRepository db)
    {
    	this.repo = db ?? new SqlDataRepository();
    }
    
    public HomeController()
    	: this(null)
    {
    }

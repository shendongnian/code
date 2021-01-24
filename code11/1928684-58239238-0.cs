    public ControllerConstructor(DbConnectionInfo db)
    {
		_databaseContext = db.DbContext;
        _someManager1 = new SomeManager(_dbcontext);
    }
    public class DbConnectionInfo
	{
		public DatabaseContext DbContext { get; set; }
		public DbConnectionInfo(IHttpContextAccessor httpContextAccessor)
		{
			var user = httpContextAccessor.HttpContext.User;
            //for question example
			DbContext = new DatabaseContext(user.Identity.GetConnectionString);
		}
	}
    [Authorize]
    public ActionResult Api_1()
    {
        //some api_1 stuff
    }

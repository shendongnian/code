    public DbContext(DbContextOptions<DbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        if (httpContextAccessor != null)
        {
            var principal = httpContextAccessor.HttpContext.User;
            //do stuff here with principal
        }
   }

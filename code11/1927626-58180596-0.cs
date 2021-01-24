    private readonly ApplicationDbContext _context;
    public readonly IPasswordHasher<IdentityUser> _passwordHasher;
    public HomeController( ApplicationDbContext dbContext, IPasswordHasher<IdentityUser> _passwordHasher)
    {
        this._context = dbContext;
        this._passwordHasher = _passwordHasher;
    }

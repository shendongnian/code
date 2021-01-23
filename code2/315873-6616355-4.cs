    private readonly IUserRepository _repo;
    public UserController(IUserRepository repo)
    {
        _repo = repo;
    }
    public UserController(): this(new UserRepository())
    {
    }

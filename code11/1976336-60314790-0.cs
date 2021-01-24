    public LoginBL(IConfiguration config)
    {
        _config = config;
    }
    public LoginBL(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

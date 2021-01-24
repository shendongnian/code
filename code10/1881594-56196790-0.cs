    public static void Test01()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, Authentication>();
            cfg.CreateMap<Authentication, User>();
        });
    
        var mapper = config.CreateMapper();
    
        var authentication = mapper.Map<User, Authentication>(new User { Email = "email", Password = "pass", Firstname = "first", Lastname = "last" });
        
        var user = mapper.Map<Authentication, User>(new Authentication { Email = "email", Password = "pass" });
    }

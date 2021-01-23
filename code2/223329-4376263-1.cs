    public MyThing(IServiceLocator services, string userName)
    {
        User user = services.UserService.GetUserByName(userName);
        int? userId = user == null ? null : (int?)user.Id;
        
        Initialize(services, userId);
    }
    
    
    public MyThing(IServiceLocator services, int? userId)
    {
        Initialize(services, userId);
    }
    
    private void Initialize(IServiceLocator services, int? userId)
    {
        // initialization logic
    }

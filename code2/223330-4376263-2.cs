    private MyThing(IServiceLocator services, int? userId)
    {
        // blah....
    } 
    public static Create(IServiceLocator services, int? userId)
    {
        return new MyThing(services, userId);
    }
    
    public static Create(IServiceLocator services, string userName)
    {
        User user = services.UserService.GetUserByName(userName);
        int userId = user == null ? null : (int?)user.Id;
        
        return new MyThing(services, userId);
    }

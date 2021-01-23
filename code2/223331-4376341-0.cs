    public MyThing(IServiceLocator services, int? userId)
    {
        // blah....
    }
    public MyThing(IServiceLocator services, string userName)
        : this(services, GetUserId(services, userName))
    {
    }
    private static int? GetUserId(IServiceLocator services, string userName)
    {
        User user = services.UserService.GetUserByName(userName);
        return (user == null) ? (int?)null : user.Id;
    }

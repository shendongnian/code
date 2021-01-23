    public UserCommandInputMapperResponse Invoke(UserCommandInputMapperRequest request)
    {
      var container = new WindsorContainer();
      container.Install(FromAssembly.This());
    
      IUserInputCommand instance;
    
      try
      {
        instance = container.Resolve<IUserInputCommand>(request.CommandName.ToLower().Trim());
      }
      catch (Exception)
      {
         instance = null;
       }
    
       return new UserCommandInputMapperResponse
                    {
                       CommandInstance = instance
                    };
    }

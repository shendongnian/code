    public void GetUserInfo()
    {
        ServiceContext context = new ServiceContext();
        context.Load<UserDTO>(ServiceContext.GetUserAccountDetailsQuery(), load =>
        {
            // do some work here
            //like signalling the call is complete
            // or storing the data in your View Model
        }, null);
    }

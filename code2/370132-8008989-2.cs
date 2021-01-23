    interface IGetUsername
    {
        string GetUsername();
    }
    
    class UsernameViaProviderOne : IGetUsername
    {
        public string GetUsername()
        {
            return new ProviderOne.AuthService().GetUsername();
        }
    }
    
    class UsernameViaProviderTwo : IGetUsername
    {
        public string GetUsername()
        {
            return new ProviderTwo.AuthService().GetUsername();
        }
    }

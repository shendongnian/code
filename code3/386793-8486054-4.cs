    public class MyUserService : IUserService
    {
        ILogger _logger = LogFactory.Instance.GetLogger<MyUserService>();
        public void SomeMethod()
        {
            _logger.Debug("Welcome world!");
        }
    }

    public class MyBusinessLogicClass
    {
        private readonly IUserContext _userContext;
        public MyBusinessLogicClass(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public void SomeOtherMethod(Whatever whatever)
        {
            var user = _userContext.GetCurrentUser();
            // do whatever you need to with that user
        }
    }

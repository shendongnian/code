    public class SomeBusinessClassSecurityInterceptor : ISomeBusinessClass
    {
        private readonly ISomeBusinessClass _inner;
        private readonly IUserContext _userContext;
        public SomeBusinessClassSecurityInterceptor(
            ISomeBusinessClass inner, IUserContext userContext)
        {
            _inner = inner;
            _userContext = userContext;
        }
        public void UpdateSomeData(Foo data)
        {
            if(!CanUpdate()) 
                throw new YouCantUpdateThisException();
            _inner.UpdateSomeData(data);
        }
        private bool CanUpdate()
        {
            var user = _userContext.GetCurrentUser();
            // make some decision based on the user
        }   
    }

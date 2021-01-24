    public class Auth : IAuth
    {
        private readonly List<AuthDetail> _auths;
        public Auth(IOptions<AuthOptions> authOptions)
        {
            _auths = authOptions.Value?.Auths;
        }
        ...
    }

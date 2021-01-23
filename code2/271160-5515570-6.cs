    public class AuthenticationService : IAuthenticationService
    {
        private readonly ISession _session;
        public AuthenticationService(ISession session)
        {
            _session = session;
        }
    
        public bool EmailIsUnique(string email)
        {
            var user = _session.Single<User>(u => u.Email == email);
            return user == null;
        }
    }

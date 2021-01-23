    public class UserService
    {
        UserService(AuthenticationService a) { }
    }
    public class AuthenticationService 
    {
        AuthenticationService() { }
        public UserService UserService { get; set; }
    }

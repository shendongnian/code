    public class AuthAttribute : ActionFilterAttribute
    {
        public Roles _authRoles { get; private set; }
    
        [Inject]
        private readonly IAuthorizationService _service;
    
        public AuthAttribute(Roles roles)
        {
            _authRoles = roles;
        }
    
        public AuthAttribute(Roles roles, IAuthorizationService authSvc)
            : this(roles)
        {
            this.service = authSvc;
        }
    
        // ...
    }

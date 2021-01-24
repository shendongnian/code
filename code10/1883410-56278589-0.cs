    public class CustomPrincipal : ClaimsPrincipal
    {
        public CustomPrincipal(IEnumerable<ClaimsIdentity> identities, string phone)
             : base(identities)
        {
            this.PhoneNumber = phone;
        }
        // My properties that I need.
        public string PhoneNumber { get; }
    }
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            ... other code ...
            context.Principal = new CustomPrincipal( <stuff to set> );
        }
    }

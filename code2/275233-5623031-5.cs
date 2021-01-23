    public CustomAuthorizeAttribute : AuthorizeAttribute 
    {
        public override void OnAuthorization(AuthorizationContext filterContext) 
        {            
            base.OnAuthorization(filterContext);
            
            // Auhtorization logic here
        }
    }

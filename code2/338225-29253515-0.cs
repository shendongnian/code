    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public static Func<IAuthorizeService> AuthorizeServiceFactory { get; set; } 
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            AuthorizeServiceFactory().AuthorizeCore(httpContext);
        }
    }

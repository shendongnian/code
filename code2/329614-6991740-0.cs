    public class SomeAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var filter = new SomeAuthorizeFilter(DependencyLookup.Resolve<IAuthorization>());
            filter.OnAuthorization(filterContext);
        }
    }
    public class SomeAuthorizeFilter : IAuthorizationFilter
    {
        private readonly IAuthorization _authorization;
        public SomeAuthorizeFilter(IAuthorization authorization)
        {
            _authorization = authorization;
        }
        protected virtual ActionResult ResultWhenNotAuthenticated(AuthorizationContext filterContext)
        {
            //snip..
            //default
            RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary
                                                                {
                                                                    {"action", "Index"},
                                                                    {"controller", "Home"}
                                                                };
            return new RedirectToRouteResult(redirectTargetDictionary);
        }
        #region IAuthorizationFilter Members
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!_authorization.GetCurrentUserIdentity().IsAuthenticated)
            {
                filterContext.Result = ResultWhenNotAuthenticated(filterContext);
            }
        }
        #endregion
    }

        public bool RedirectAuthenticatedButUnauthorizedUsers { get; set; }
        private String _redirectUnauthorizedUrl = String.Empty;
        public String RedirectUnauthorizedUrl
        {
            get { return _redirectUnauthorizedUrl; }
            set { _redirectUnauthorizedUrl = value.Trim(); }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (!RedirectAuthenticatedButUnauthorizedUsers || !filterContext.HttpContext.Request.IsAuthenticated)
                return;
            if(RedirectUnauthorizedUrl == String.Empty)
                throw new NullReferenceException("RedirectAuthenticatedButUnauthorizedUsers " +
                                                 "set to true, but no redirect URL set.");
            filterContext.HttpContext.Response.Redirect(RedirectUnauthorizedUrl);
        }

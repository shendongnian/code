    namespace WpRegistration.Web.Filters 
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public sealed class AgencyAuthorize : ActionFilterAttribute
        {
            CurrentUserService _currentUserSvc;
            public AgencyAuthorize() { }
    
            public CurrentUserService Service
            {
                get { return _currentUserSvc; }
                set
                {
                    this._currentUserSvc=value;
                }
            }

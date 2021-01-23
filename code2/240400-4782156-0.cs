    public static class NinjectSessionScopingExtention
    {
        public static void InSessionScope<T>(this IBindingInSyntax<T> parent)
        {
            parent.InScope(SessionScopeCallback);
        }
    
        private const string _sessionKey = "Ninject Session Scope Sync Root";
        private static object SessionScopeCallback(IContext context)
        {
            if (HttpContext.Current.Session[_sessionKey] == null)
            {
                HttpContext.Current.Session[_sessionKey] = new object();
            }
    
            return HttpContext.Current.Session[_sessionKey];
        }
    }

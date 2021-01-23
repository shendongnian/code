    public class MyAuthHandlerSelector : IHandlerSelector
    {
        public bool HasOpinionAbout(string key, Type service)
        {
            return service == typeof(ITheServiceICareAbout);
        }
 
        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            return IsAuthenticated 
                ? FindHandlerForAuthenticatedUser(handlers)
                : FindGuestHandler(handlers);
        }
        bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal != null; } 
        }
        // ....
    }

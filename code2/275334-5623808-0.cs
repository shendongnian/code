    public class MyModelBinder : IModelBinder
    {
        Func<IAuthenticationService> _resolveAuthService;
        
        public MyModelBinder(Func<IAuthenticationService> resolveAuthService)
        {
             _resolveAuthService = resolveAuthService;
        }
        
        public override object Bind(Context c)
        {
            var authService = _resolveAuthService();
            
            authService.GetSomething();
            
            // etc...
        }
    }

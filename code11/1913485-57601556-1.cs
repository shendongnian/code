    public class MyRouter : IRouter
    {
        private readonly IRouter _defaultRouter;
        public MyRouter (IRouter defaultRouter)
        {
            _defaultRouter = defaultRouter;
        }
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return _defaultRouter.GetVirtualPath(context);
        }
        public async Task RouteAsync(RouteContext context)
        {
        } 
    }

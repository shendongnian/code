        public class DevOnlyActionFilter : ActionFilterAttribute
        {
            private IHostingEnvironment HostingEnv { get; }
            public DevOnlyActionFilter(IHostingEnvironment hostingEnv)
            {
                HostingEnv = hostingEnv;
            }
    
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if(!HostingEnv.IsDevelopment())
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    context.Result = new ContentResult() { Content = "" };
    
                    return;
                }
                
                base.OnActionExecuting(context);
            }
        }

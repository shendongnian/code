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
                    context.Result = new NotFoundResult();
                    return;
                }
                
                base.OnActionExecuting(context);
            }
        }

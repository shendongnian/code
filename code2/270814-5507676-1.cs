    protected virtual void Execute(RequestContext requestContext) {
                if (requestContext == null) {
                    throw new ArgumentNullException("requestContext");
                }
                if (requestContext.HttpContext == null) {
                    throw new ArgumentException(MvcResources.ControllerBase_CannotExecuteWithNullHttpContext, "requestContext");
                }
    
                VerifyExecuteCalledOnce();
                Initialize(requestContext);
    
                using (ScopeStorage.CreateTransientScope()) {
                    ExecuteCore();
                }
            }

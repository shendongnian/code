        static YourCodeHere()
        {
            PrivilegedCommand cmd = new PrivilegedCommand();
            SecurityCritical.ExecutePrivileged(new PermissionSet(PermissionState.Unrestricted), new SecurityCritical.PrivilegedCallback(cmd.Execute));
            handlerFactory = cmd.Result;
        }
        private class PrivilegedCommand
        {
            public IHttpHandlerFactory Result = null;
            public void Execute()
            {
                Type handlerFactoryType = typeof(IHttpHandler).Assembly.GetType("System.Web.UI.WebServiceHandlerFactory");
                Result = (IHttpHandlerFactory)Activator.CreateInstance(handlerFactoryType, true);
            }
        }

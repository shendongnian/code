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
                Type handlerFactoryType = typeof(System.Web.Services.WebService).Assembly.GetType("System.Web.Services.Protocols.WebServiceHandlerFactory");
                Result = (IHttpHandlerFactory)Activator.CreateInstance(handlerFactoryType, true);
            }
        }
    /// <summary>
    /// Utility class to be used from within this assembly for executing security critical code 
    /// NEVER EVER MAKE THIS PUBLIC!
    /// </summary>
    /// <author>Erich Eichinger</author>
    internal class SecurityCritical
    {
        internal delegate void PrivilegedCallback();
        [SecurityCritical, SecurityTreatAsSafe]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void ExecutePrivileged(IStackWalk permission, PrivilegedCallback callback)
        {
            permission.Assert();
            try
            {
                callback();
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
            }
        }
    }

    public class PluginVerifier
    {
        public static int CheckPlugin(string arguments)
        {
            AppDomain appDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString());
            appDomain.UnhandledException += AppDomainUnhandledException;
            object obj = appDomain.CreateInstanceAndUnwrap("ExceptionThrower", "ExceptionThrower.MainExceptionThrower");
            object ret = obj.GetType().InvokeMember("Startup", BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod, null, obj, new object[] { arguments });
            AppDomain.Unload(appDomain);
            return (int)ret;
        }
        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            AppDomain appDomain = (AppDomain)sender;
            // the following will prevent "this should never print" to happen
            AppDomain.Unload(appDomain);
        }
    }

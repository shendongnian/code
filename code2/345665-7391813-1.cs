    public class InitialisePluginStrategy : IExportedValueInterceptor
    {
        public object Intercept(object value)
        {
            var plugin = value as IPlugin;
            if (plugin != null)
                plugin.Initialise();
            return value;
        }
    }

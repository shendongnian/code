    public class FilteredLogFactory : LogFactory
    {
        public override ILogger GetLogger<T>()
        {
            if (typeof(ITextParser).IsAssignableFrom(typeof(T)))
                return new FilteredLogger(typeof(T));
    
            return new FileLogger(@"C:\Logs\MyApp.log");
        }
    }

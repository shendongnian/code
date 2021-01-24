    public class IOC
    {
        public static IServiceProvider CurrentProvider { get; internal set; }
    
        public static T resolve<T>()
        {
            return CurrentProvider.GetService<T>();
        }
    }

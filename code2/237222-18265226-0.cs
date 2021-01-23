    private static void Main(string[] args)
    {
        var serviceBases = new ServiceBase[] {new Service() /* ... */ };
    
    #if DEBUG
        if (Environment.UserInteractive)
        {
            const BindingFlags bindingFlags =
                BindingFlags.Instance | BindingFlags.NonPublic;
    
            foreach (var serviceBase in serviceBases)
            {
                var serviceType = serviceBase.GetType();
                var methodInfo = serviceType.GetMethod("OnStart", bindingFlags);
    
                new Thread(service => methodInfo.Invoke(service, new object[] {args})).Start(serviceBase);
            }
    
            return;
        }
    #endif
    
        ServiceBase.Run(serviceBases);
    }

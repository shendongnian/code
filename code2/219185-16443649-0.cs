    static class Program
    {
        static void Main()
        {
            var servicesToRun = new ServiceBase[] 
                { 
                    new CassetteDeckService() 
                };
            if (Environment.UserInteractive)
            {
                var type = typeof(ServiceBase);
                const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
                var method = type.GetMethod("OnStart", flags);
                foreach (var service in servicesToRun)
                {
                    method.Invoke(service, new object[] { null });
                }
                Console.WriteLine("Service Started!");
                Console.ReadLine();
                method = type.GetMethod("OnStop", flags);
                foreach (var service in servicesToRun)
                {
                    method.Invoke(service, null);
                }
                Environment.Exit(0);
            }
            else
            {
                ServiceBase.Run(servicesToRun);
            }
        }
    }

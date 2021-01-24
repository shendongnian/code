        private static void Main()
        {
    #if DEBUG
            new RuntimeService().RunDebugMode();
            System.Threading.Thread.Sleep(TimeSpan.FromDays(1));
    #else
            ServiceBase.Run(new RuntimeService());
    #endif
        }

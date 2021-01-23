    static class Entry
    {
        private static WebClient webClient;
    
        static void Main()
        {
            Initialize();
            RunMainLoop();
            Uninitialize();
        }
    
        private static void Initialize()
        {
            webClient = ...;
        }
    
        private static void Uninitialize()
        {
            webClient.Dispose();
        }
    }

        static bool dummy = RegisterUnhandledExceptionHandler();
        private static bool RegisterUnhandledExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Console.WriteLine((e.ExceptionObject as Exception).StackTrace);
                throw (e.ExceptionObject as Exception);
            }
            return true;
        }

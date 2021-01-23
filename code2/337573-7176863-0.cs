        static bool dummy = RegisterUnhandledExceptionHandler();
        private static bool RegisterUnhandledExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => Console.WriteLine((e.ExceptionObject as Exception).StackTrace);
            return true;
        }

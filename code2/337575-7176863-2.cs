        static bool dummy = RegisterUnhandledExceptionHandler();
        private static bool RegisterUnhandledExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception ex = (e.ExceptionObject as Exception);
                // quick dump to file because environment will exit soon
                File.WriteAllText("unhandled.txt", ex.StackTrace);
                throw ex;
            }
            return true;
        }

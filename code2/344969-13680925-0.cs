    public static class CrashHandler
    {
        public static void Setup()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        }
        public static Task CrashOnUnhandledException(this Task t)
        {
            t.ContinueWith(x => HandleException(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
            return t;
        }
        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject);
        }
        private static void HandleException(object ex)
        {
            ShowErrorMessage(ex);
            Environment.Exit(-1);
        }
        private static void ShowErrorMessage(object ex)
        {
            // your crash dialog goes here
        }
    }

    public static class CrashesExtensions
    {
        public static void TrackErrorLive(Exception ex)
        {
            if (!Debugger.IsAttached) Crashes.TrackError(ex);
        }
    }

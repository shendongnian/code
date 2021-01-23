    public static class Extension
    {
        public static bool IsOneTimeLaunch(this Application application, string uniqueName = null)
        {
            var applicationName = Path.GetFileName(Assembly.GetEntryAssembly().GetName().Name);
            uniqueName = uniqueName ?? string.Format("{0}_{1}_{2}",
                Environment.MachineName,
                Environment.UserName,
                applicationName);
            application.Exit += (sender, e) => mutex.Dispose();
            bool isOneTimeLaunch;
            mutex = new Mutex(true, uniqueName, out isOneTimeLaunch);
            return isOneTimeLaunch;
        }
    }

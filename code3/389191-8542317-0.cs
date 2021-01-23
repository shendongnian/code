    public static class UsageClass
    {
        private static ExternalApplications _extApps;
        public static void Initialize()
        {
            _extApps = null;
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                    goto default;
                case PlatformID.MacOSX:
                    _extApps = new ExternalApplicationsMac(); break;
                case PlatformID.Unix:
                    _extApps = new ExternalApplicationsUnix(); break;
                default:
                    _extApps = new ExternalApplicationsWin(); break;
            }
        }
        internal abstract class ExternalApplications
        {
            public abstract string[] DoSomething();
        }
        internal class ExternalApplicationsWin : ExternalApplications
        {
            public abstract void DoSomething()
            {
                // Windows code
                RegistryKey regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                    (Environment.Is64BitOperatingSystem) ? RegistryView.Registry64 : RegistryView.Registry32).OpenSubKey("SOFTWARE\MySoft");
                ...
            }
        }
        internal class ExternalApplicationsUnix : ExternalApplications
        {
            public abstract void DoSomething()
            {
                // Unix code
            }
        }
        internal class ExternalApplicationsMac : ExternalApplications
        {
            public abstract void DoSomething()
            {
                // Mac code
            }
        }
    } 

    public static class VistaSecurity
    {
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            if (null != identity)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            return false;
        }
        public static Process RunProcess(string name, string arguments)
        {
            string path = Path.GetDirectoryName(name);
            if (String.IsNullOrEmpty(path))
            {
                path = Environment.CurrentDirectory;
            }
            ProcessStartInfo info = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = path,
                FileName = name,
                Arguments = arguments
            };
            if (!IsAdministrator())
            {
                info.Verb = "runas";
            }
            try
            {
                return Process.Start(info);
            }
            catch (Win32Exception ex)
            {
                Trace.WriteLine(ex);
            }
            return null;
        }
    }

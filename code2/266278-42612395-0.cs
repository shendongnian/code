    public static class ServiceLocator
    {
        public static bool IsWcfStarted()
        {
            Process[] ProcessList = Process.GetProcesses();
            return ProcessList.Any(a => a.ProcessName.StartsWith("MyApplication.Service.Host", StringComparison.Ordinal));
        }
    
    
        public static void StartWcfHost()
        {
    
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    
            var Process2 = new Process();
            var Start2 = new ProcessStartInfo();
            Start2.FileName = Path.Combine(path, "Service", "MyApplication.Service.Host.exe");            
            Process2.StartInfo = Start2;
            Process2.Start();
        }
    }

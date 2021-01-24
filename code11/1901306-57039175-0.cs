    public static void NgenApplication()
        {
            if (!ApplicationDeployment.IsNetworkDeployed || !ApplicationDeployment.CurrentDeployment.IsFirstRun) return;
            string appPath = Application.StartupPath;
            string winPath = Environment.GetEnvironmentVariable("WINDIR");
            using (var proc = new Process())
            {
                Directory.SetCurrentDirectory(appPath);
                proc.EnableRaisingEvents = false;
                proc.StartInfo.CreateNoWindow = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.FileName = $@"{winPath}\Microsoft.NET\Framework\v2.0.50727\ngen.exe";
                proc.StartInfo.Arguments = $"uninstall {Application.ProductName} /nologo /silent";
                proc.Start();
                proc.WaitForExit();
                proc.StartInfo.FileName = $@"{winPath}\Microsoft.NET\Framework\v2.0.50727\ngen.exe";
                proc.StartInfo.Arguments = $"install {Application.ProductName} /nologo /silent";
                proc.Start();
                proc.WaitForExit();
            }
        }

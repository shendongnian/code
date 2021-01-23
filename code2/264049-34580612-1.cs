    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var appDir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            if (!File.Exists($"{appDir}\\<app>.exe"))
            {
                File.Copy($"{appDir}\\<app>.exe.bin", $"{appDir}\\<app>.exe");
            }
        }
    }

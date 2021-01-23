    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Process p = Process.Start(@"exe file path");
            p.WaitForExit();
            p.Dispose();
            base.OnStartup(e);
        }
    }

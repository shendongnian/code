    public class LocApp: Application
    {
        [STAThread]
        public static void Main()
        {
            App app = new App();
            app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            wndMain wnd = new wndMain();
            wnd.Closed += Wnd_Closed;
            app.Run(wnd);
        }
        private static void Wnd_Closed(object sender, EventArgs e)
        {
            wndMain wnd = sender as wndMain;
            if (!string.IsNullOrEmpty(wnd.LangSwitch))
            {
                string lang = wnd.LangSwitch;
                wnd.Closed -= Wnd_Closed;
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                wnd = new wndMain();
                wnd.Closed += Wnd_Closed;
                wnd.Show();
            }
            else
            {
                App.Current.Shutdown();
            }
        }
    }

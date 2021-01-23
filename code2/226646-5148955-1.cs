      public partial class MainWindow : Window
    {
        private Window _window;
        public MainWindow()
        {
        InitializeComponent();
            SetStartup("AppName", true);
        }
     private void SetStartup(string AppName, bool enable)
        { 
            string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            Microsoft.Win32.RegistryKey startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey); 
            if (enable)
            { 
                if (startupKey.GetValue(AppName) == null) 
                { 
                    startupKey.Close(); 
                    startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                    startupKey.SetValue(AppName, Assembly.GetExecutingAssembly().Location + " /StartMinimized");
                    startupKey.Close(); 
                }
            } 
            else 
            {
                startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                startupKey.DeleteValue(AppName, false); 
                startupKey.Close(); 
            }
        }
     private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Minimized)
            {
                var minimized = (_window.WindowState == WindowState.Minimized);
                _window.ShowInTaskbar = !minimized;
            }
            else
                ShowInTaskbar = true;
        }

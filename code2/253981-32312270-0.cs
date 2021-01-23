    public partial class MainWindow : Window
        {
            // The path to the key where Windows looks for startup applications
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
    
            public MainWindow()
            {
                InitializeComponent();
                if (this.IsFocused)
                {
                    this.Topmost = true;
                }
                else
                {
                    this.Topmost = false;
                }
    
                // Check to see the current state (running at startup or not)
                if (rkApp.GetValue("StartupWithWindows") == null)
                {
                    // The value doesn't exist, the application is not set to run at startup, Check box
                    chkRun.IsChecked = false;
                    lblInfo.Content = "The application doesn't run at startup";
                }
                else
                {
                    // The value exists, the application is set to run at startup
                    chkRun.IsChecked = true;
                    lblInfo.Content = "The application runs at startup";
                }
                //Run at startup
                //rkApp.SetValue("StartupWithWindows",System.Reflection.Assembly.GetExecutingAssembly().Location);
    
                // Remove the value from the registry so that the application doesn't start
                //rkApp.DeleteValue("StartupWithWindows", false);
    
            }
    
            private void btnConfirm_Click(object sender, RoutedEventArgs e)
            {
                if ((bool)chkRun.IsChecked)
                {
                    // Add the value in the registry so that the application runs at startup
                    rkApp.SetValue("StartupWithWindows", System.Reflection.Assembly.GetExecutingAssembly().Location);
                    lblInfo.Content = "The application will run at startup";
                }
                else
                {
                    // Remove the value from the registry so that the application doesn't start
                    rkApp.DeleteValue("StartupWithWindows", false);
                    lblInfo.Content = "The application will not run at startup";
                }
            }
    
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            if (System.Windows.Application.Current == null)
            {
                app = new WPFTest.App()
                {
                    ShutdownMode = ShutdownMode.OnExplicitShutdown
                };
                app.InitializeComponent();
            }
            else
            {
                app = (WPFTest.App)System.Windows.Application.Current;
                app.MainWindow = new WPFTest.YourWindow();
                System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(app.MainWindow);
                app.MainWindow.Show();
            }
        }

    public partial class App : Application
    {
        public static SynchronizationContext SynchronizationContext;
        protected override void OnStartup(StartupEventArgs e)
        {
            // This is my preferred way of accessing the correct SynchronizationContext in a WPF app
            SynchronizationContext = SynchronizationContext.Current;
            base.OnStartup(e);
            var mainWindow = MainWindow;
            var t = new Thread(() => {
                Thread.Sleep(3000);
                SynchronizationContext.Post(state => {
                    mainWindow.Hide(); // this will not throw an exception
                }, null);
                mainWindow.Close(); // this will throw an exception
            });
            t.Start();
        }
    }

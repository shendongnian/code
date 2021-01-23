        using System.Threading;
        protected override void OnStartup(StartupEventArgs e)
        {
            bool result;
            Mutex oMutex = new Mutex(true, "Global\\" + "YourAppName",
                 out result);
            if (!result)
            {
                MessageBox.Show("Already running.", "Startup Warning");
                Application.Current.Shutdown();
            }
            base.OnStartup(e);
        }

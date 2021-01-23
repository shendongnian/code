    public partial class App : Application
    {      
        private const string AppId = "c1d3cdb1-51ad-4c3a-bdb2-686f7dd10155";
        
        //Passing name associates this sempahore system wide with this name
        private readonly Semaphore instancesAllowed = new Semaphore(1, 1, AppId);
        
        private bool WasRunning { set; get; }
        private void OnExit(object sender, ExitEventArgs e)
        {
            //Decrement the count if app was running
            if (this.WasRunning)
            {
                this.instancesAllowed.Release();
            }
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            //See if application is already running on the system
            if (this.instancesAllowed.WaitOne(1000))
            {
                new MainWindow().Show();
                this.WasRunning = true;
                return;
            }
            //Display
            MessageBox.Show("An instance is already running");
            //Exit out otherwise
            this.Shutdown();
        }
    }

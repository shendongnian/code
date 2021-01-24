    protected override void OnInitialize()
        {
            var windowManager = new WindowManager();
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.DoWork += InitializeApplication;
                bw.RunWorkerCompleted += InitializationCompleted;
                bw.RunWorkerAsync();
                windowManager.ShowDialog(new AnimatedSplashViewModel(_events));
            }
        }

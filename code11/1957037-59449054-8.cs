    private SplashScreen { get; set; }
    protected override async void OnStartup(StartupEventArgs e)
    {
      // Initialize the splash screen.
      // The first Window shown becomes automatically the Application.Current.MainWindow
      this.SplashScreen = new MySplashScreen();
      this.SplashScreen.Show();
    
      // Create a Progress<T> instance which automatically 
      // captures the current SynchronizationContext (UI thread)
      // which makes the Dispatcher obsolete for reporting the progress to the UI. 
      // Pass a report (UI update) callback to the Progress<T> constructor,
      // which will execute automatically on the UI thread.
      // Because of the generic parameter which is in this case of type ValueTuple (C# 7),
      // 'System.ValueTuple' is required to be referenced (see NuGet)
      var progressReporter = new Progress<(int Value, string Message)>(ReportProgress);
      // Wait asynchronously for the background task to complete
      await DoWorkAsync(progressReporter);
      // Override the Application.Current.MainWindow instance.
      this.MainWindow = new MainWindow();
      // Asynchronously wait until MainWindow is initialized
      // Pass the Progress<T> instance to the method,
      // so that MainWindow can report progress too
      await this.MainWindow.InitializeAsync(progressReporter);
    
      this.SplashScreen.Close();    
      this.MainWindow.Show();    
    }
    private async Task DoWorkAsync(IProgress<(int Value, string Message)> progressReporter)
    {
      // In order to ensure the UI stays responsive, we need to
      // do the work on a different thread
      await Task.Run(
        async () =>
        {
          // We need to do the work in batches so that we can report progress
          for (int i = 1; i <= 100; i++)
          {
            // Simulate a part of work being done
            await Task.Delay(30);
            
            progressReporter.Report((i, i.ToString()));            
          }
        });
    }
    // The progress report callback which is automatically invoked on the UI thread.   
    // Requires 'System.ValueTuple' to be referenced (see NuGet)
    private void ReportProgress((int Value, string Message) progress)
    {
      this.SplashScreen.Progress = progress.Value;
      this.SplashScreen.MyText = progress.Message;
    }

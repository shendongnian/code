    using System.Threading;
 
    /// -------------------------------
    private Timer t;
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        App.MainWindow = new MainWindow(); // Creates but wont show
        t = new Timer(new TimerCallback(CloseSplash), null, new TimeSpan(0,0,10), new TimeSpan(0,0,0,0,-1));
        // Do Other load stuff here?
    }
    private void CloseSplash(object info)
    {
         // Dispatch to UI Thread
        Dispatcher.Invoke(DispatcherPriority.Normal, x => CloseSplashMain());
    }
    private void CloseSplashMain()
    {
       App.MainWindow.Show()
       this.Close();
    }

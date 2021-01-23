    private void LongRunningTask() 
    {
       // your long running code
       
       // after you complete:
       Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Send,
                               (Action)delegate
        {
            wait.IsBusy = false;
        }); 
    }
    private void esp_Click(object sender, RoutedEventArgs e)
    {
       wait.IsBusy = true; // either here, or in your long running task - but then remember to use dispatcher
 
       var thread = new Thread(LongRunningTask);
       thread.Start();
       // OR
       ThreadPool.QueueUserWorkItem(state => LongRunningState());
       // OR, in .NET 4.0
       
       Task.Factory.StartNew(LongRunningTask);
    }

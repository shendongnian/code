    void myButton_Click(object sender, RoutedEventArgs e)
    {
        busyIndicator.IsBusy = true;
        // Start your background work - this has to be done on a separate thread,
        // for example by using a BackgroundWorker
        var worker = new BackgroundWorker();
        worker.DoWork += (s,ev) => DoSomeWork();
        worker.RunWorkerCompleted += (s,ev) => busyIndicator.IsBusy = false;
        worker.RunWorkerAsync();
    }
       

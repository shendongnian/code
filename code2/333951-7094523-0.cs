    private void solveButton_Click(object sender, RoutedEventArgs e)
    {
        progressBar1.Visibility = Visibility.Visible;
        progressBar1.IsIndeterminate = true;
      
        //Start background worker here asynchronously
        //and solve the problem inside backgroundworker 
        //also set a method which will be called once background worker has completed working
    }
    
    BackGroundWorkerMethodComplete()
    {
        //once the background worker is complete
        //hide the progress bar using Dispatcher
        progressBar1.Visilibity=Visilibity.collapsed;
        progressBar1.IsIndeterminate = false;
    }

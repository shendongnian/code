    private void RunButton_Click(object sender, RoutedEventArgs e)
    {
        ThreadPool.QueueUserWorkItem(
            delegate
            {
                // Do work
                Dispatcher.Invoke(new Action(
                   delegate 
                   { 
                       // Do UI stuff
                   }));
                // Do more work
                Dispatcher.Invoke(new Action(
                   delegate 
                   { 
                       // Do UI stuff
                   }));
            });
    }

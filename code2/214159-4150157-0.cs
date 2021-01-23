    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        //Collapse Window
        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object o)
        {
            this.Visibility = Visibility.Collapsed;
            return null;
        }, null);
        //Do not close Window
        e.Cancel = true;
    }

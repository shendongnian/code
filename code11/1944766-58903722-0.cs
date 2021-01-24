    private void CallDisconnect()
    {
        Disconnect();
        if (btnAutoDisconnect.Checked)
            Dispatcher.InvokeAsync(()=> CallDisconnect(), DispatcherPriority.Normal);
    }
    
    private void btnAutoDisconnect_Checked(object sender, RoutedEventArgs e)
    {
        CallDisconnect();
    }

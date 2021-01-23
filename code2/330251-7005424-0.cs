    private void HandleUIButtons()
    {    
        if (!btnSplit.Dispatcher.CheckAccess())   
        {         
            //if here - we are on a different non-UI thread        
            btnSplit.Dispatcher.BeginInvoke(new Action(HandleUIButtons));    
        }    
        else        
        {
            btnSplit.IsEnabled = true; //this is ultimately run on the UI-thread
        }
    }

    private void MiniClockEventProcessor(Object myObject, EventArgs myEventArgs)
    {
       if (!IsAlertState)
       {
           notifyIcon1.Icon = Properties.Resources.LogoIcon;
       }
       else
           notifyIcon1.Icon = Properties.Resources.AlertIcon;
    
    }
    
    private bool IsAlertState {get;set}

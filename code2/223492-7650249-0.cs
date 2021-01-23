    public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom)
    {
        // As this is an Outlook-only extension, we know the application object will be an Outlook application
        _applicationObject = (Microsoft.Office.Interop.Outlook.Application)application;
        
        // Make sure we're notified when Outlook 2010 is shutting down
        ((Microsoft.Office.Interop.Outlook.ApplicationClass)_applicationObject).ApplicationEvents_Event_Quit += new ApplicationEvents_QuitEventHandler(Connect_ApplicationEvents_Event_Quit);
    }
    
    private void Connect_ApplicationEvents_Event_Quit()
    {
        Array emptyCustomArray = new object[] { };
        OnBeginShutdown(ref emptyCustomArray);
    }
    
    public void OnDisconnection(Extensibility.ext_DisconnectMode disconnectMode, ref System.Array custom)
    {
        addinShutdown();
    }
    
    public void OnBeginShutdown(ref System.Array custom)
    {
        addinShutdown();
    }
    
    private void addinShutdown()
    {
        // Code to run when addin is being unloaded, or Outlook is shutting down, goes here...
    }

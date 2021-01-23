In WinForms you need to call UI-things on UI thread, you always can check on what thread you currents are getting InvokeRequired of UI-control.
    void AppliUiChanges()
    {
       if(this.InvokeRequired)
       {
           this.Invoke(new Action(AppliUiChanges));
           return;
       } 
       
       // UI stuff here...
    }
In WPF techinic is alike. But instead of using InvokeRequired you should ask CheckAccess() of [DispatcherObject][1] (All UI-controls derive from it)
 
    void AppliUiChanges()
    {
       if (!dispatcherObject.CheckAccess())
       {     
          dispatcherObject.Dispatcher.Invoke(DispatcherPriority.Send, new Action( AppliUiChanges));
          return;
       }
       // UI stuff here...
    }

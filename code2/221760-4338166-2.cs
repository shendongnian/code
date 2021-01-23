In WinForms you need to call UI-things on UI thread, you always can check on what thread you currents are getting InvokeRequired of UI-control.
    void ApplyUiChanges()
    {
       if(this.InvokeRequired)
       {
           this.Invoke(new Action(ApplyUiChanges));
           return;
       } 
       
       // UI stuff here...
    }
In WPF techinic is alike. But instead of using InvokeRequired you should ask CheckAccess() of [DispatcherObject][1] (All UI-controls derive from it)
 
    void ApplyUiChanges()
    {
       if (!dispatcherObject.CheckAccess())
       {     
          dispatcherObject.Dispatcher.Invoke(DispatcherPriority.Send, new Action(ApplyUiChanges));
          return;
       }
       // UI stuff here...
    }

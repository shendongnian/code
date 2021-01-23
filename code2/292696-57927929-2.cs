    System.InvalidOperationException
      HResult=0x80131509
      Message=The calling thread cannot access this object because a different thread owns it.
      Source=WindowsBase
      StackTrace:
       at System.Windows.Threading.Dispatcher.VerifyAccess()
       at System.Windows.DependencyObject.GetValue(DependencyProperty dp)
       at System.Windows.Controls.Primitives.Selector.get_SelectedValue()
       at ...
       at System.Timers.Timer.MyTimerCallback(Object state)

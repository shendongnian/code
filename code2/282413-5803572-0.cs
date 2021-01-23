    if (control.Dispatcher.CheckAccess())
    {
       ...
    }
    else
    {
       control.Dispatcher.Invoke(...)
    }

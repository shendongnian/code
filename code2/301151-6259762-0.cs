    if(Dispatcher.CurrentDispatcher.CheckAccess())
    {
       <Code here>
    }
    else
    {
       Dispatcher.CurrentDispatcher.Invoke(<Code here>)
    }

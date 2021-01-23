    var iars = new List<IAsyncResult>();
    Action<IDisposable> disposeAction = a => { a.Dispose(); foos.Remove(a); }
    foreach(var foo in foos)
        iars.Add(disposeAction.BeginInvoke(null, null));
    // If you need to wait for all objects to be removed and disposed.
    foreach(var iar in iars)
        disposeAction.EndInvoke(iar);

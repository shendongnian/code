    var context = TaskScheduler.FromCurrentSynchronizationContext();
    
    Task<SomeResultClass>.Factory.StartNew(SomeWorkMethod).ContinueWith((t) =>
       {
          if (!myListControl.InvokeRequired)
             myListControl.Add(t.Result); // <-- this causes an exception
          else
             myListControl.Invoke((Action)(() => myListControl.Add(t.Result)));
       }, context);

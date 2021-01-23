    // create a background task to load data without blocking the UI
    Task.Factory.StartNew(() =>
    {
      var data = getData(); // call to DB or whatever
      
      // invoke user code on the main UI thread
      Dispatcher.Invoke(new Action(() =>
      {
        doSomethingWithData();
      }));
    });

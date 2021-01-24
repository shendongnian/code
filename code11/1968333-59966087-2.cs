    class MyServer
    {
     // notice async void here instead of async Task
     async void StartServerRunning(Callback callback)
      {
       await StartRunningThreadAsync(); // start server asynchronously
       callback();
      }
    }

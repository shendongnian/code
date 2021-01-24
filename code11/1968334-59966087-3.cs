    class MyServer
    {
     async void StartServerRunning(Callback callback)
      {
       bool wasError = false;
       try{
         await StartRunningThreadAsync(); // start server asynchronously
       }catch(Exception ex)
       {
         // log exception
         wasError = true;
       }
       callback(wasError);
      }
    }

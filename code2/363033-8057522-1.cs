    Task.Factory.StartNew(() => myFunction(myObject, httpSessionState))
        .ContinueWith(faultedTask => 
        { 
            var ex = faultedTask.Exception; // reading the exception will ensure the process won't terminate
            Log.Error("Task Xyz failed", ex);
        },
        TaskContinuationOptions.OnlyOnFaulted |
        TaskContinuationOptions.ExecuteSynchronously);

    public Task<string> SendAndSave(User user){
    var tcs = new TaskCompletionSource<string>();
    var task1 = SendMail(user.Email);
    var task1Failed = task1.ContinueWith(t =>   
    {
         var e = task1.Exception;
         tcs.TrySetResult("Send Failed");
    }, 
    TaskContinuationOptions.OnlyOnFaulted | 
    TaskContinuationOptions.ExecuteSynchronously);
    var task2 = task1.ContinueWith(t =>
    {
        var save = SaveToDB(user);
        try
        {
            int result = save.Result;
            tcs.TrySetResult("Save Succeeded"); 
        }
        catch(AggregateException ae)
        {
           tcs.TrySetResult("Save Failed"); 
        }
    },TaskContinuationOptions.NotOnFaulted); 
     return tcs.Task.Result;
    }

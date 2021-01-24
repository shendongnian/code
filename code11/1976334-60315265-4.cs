    private Task StartSTATask(Action action)
    {
       var tcs = new TaskCompletionSource<object>();
       Thread thread = new Thread(() =>
                                     {
                                        try
                                        {
                                           action();
                                           tcs.SetResult(null);
                                        }
                                        catch (Exception e1)
                                        {
                                           tcs.SetException(e1);
                                        }
                                     });
       thread.SetApartmentState(ApartmentState.STA);
       thread.Start();
       return tcs.Task;
    }

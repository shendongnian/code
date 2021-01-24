    public async static Task Main(string[] args)
    {
       var callback = new ThirdPartyCallbackImplementation();
       var context = new InstanceContext(callback);
       ThirdPartyClient client = new ThirdPartyClient(context);
    
       
       client.Subscribe();
       object info = await callback.WhenEventFound()
                          //timeout
                          .Take(TimeSpan.FromSeconds(10))
                          .FirstOrDefaultAsync()
                          .ToTask();
       if(info != null)
          Console.WriteLine("Something was found!");
    
       Console.ReadLine();
    }
    
    private static IObservable<object> WhenEventFound(this ThirdPartyCallbackImplementation proxy)
    {
         return Observable.FromEvent<CallBackEvent, object>(h => x => h(x),
                handler => proxy.FoundEvent += handler,
                handler => proxy.FoundEvent -= handler)
    }

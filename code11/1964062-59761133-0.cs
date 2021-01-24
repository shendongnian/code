    private async void MyAsyncMethod()
    {
       // do some asynchronous thing
       // await something
       
       // then, run below on thread pool, which would not block MyAsyncMethod
       Task.Run(() =>
       {
          DirectorySearcher ds = new DirectorySearcher();
          ds.Asynchronous = true;
          ds.Filter = "(&(objectclass=user)(samaccountname=testaccount)";
          ds.PropertiesToLoad.Add("samaccountnamt");
          SearchResult sr = ds.FindOne();
       });
    }

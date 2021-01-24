    public async Task<Page> ServePage() // No async
    {
      // Launched from this same thread, 
      // returns after ~2 seconds, 
      // continuation printed.
      await DoThings(10);
      #pragma warning disable 4014
      // Launched from this same thread, 
      // returns after ~1 second, 
      // continuation not yet printed
      DoThings(10);   
      // Task likely to be scheduled on a second thread
      // will return within << 1 second (i.e. not blocked by sleeps)
      Task.Run(() => CalculateMeaningOfLife());   
      // Task likely to be scheduled on a second thread
      // will return after 2 seconds. Wastes a thread.
      await Task.Run(() => CalculateMeaningOfLife());   
    }
    public async Task<string> DoThings(int foo) {
       Thread.Sleep(1000); 
       var result = await SomeAsyncIo(foo);
       Trace.WriteLine("Continuation!"); 
       Thread.Sleep(1000); 
       return "done!";
    }

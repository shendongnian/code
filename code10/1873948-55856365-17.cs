    public async Task<Page> ServePage()
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
      // will return within few milliseconds (i.e. not blocked by sleeps)
      Task.Run(() => DoThings(10));   
      // Task likely to be scheduled on a second thread
      // will return after 2 seconds. 
      // Generally a wasted thread unless also doing CPU bound work on current thread.
      await Task.Run(() => DoThings());   
      // Redundant state machine, returns after 2 seconds
      // see return Task vs async return await Task https://stackoverflow.com/questions/19098143
      await Task.Run(async () => await DoThings());   
    }
    public async Task<string> DoThings(int foo) {
       Thread.Sleep(1000); 
       var result = await SomeAsyncIo(foo);
       Trace.WriteLine("Continuation!"); 
       Thread.Sleep(1000); 
       return "done!";
    }

    using (new ScopedSynchronizationContext(new SynchronizationContext()))
    {
      var serviceName = new ServiceName(..);
      // Note: MyMethodCompleted will be invoked in a ThreadPool thread
      //  but WITHOUT an associated ASP.NET page, so some global state
      //  might be missing. Be careful with what code goes in there...
      serviceName.MethodCompleted += MyMethodCompleted;
      serviceName.MethodAsync(..);
    }

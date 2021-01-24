    private async Task CheckProxyServerAsync(IEnumerable<object> proxies)
    {
      var tasks = new List<Task>();
      int currentThreadNumber = 0;
      int maxNumberOfThreads = 8;
      using (semaphore = new SemaphoreSlim(maxNumberOfThreads, maxNumberOfThreads))
      {
        foreach (var proxy in proxies)
        {
          // Asynchronously wait until thread is available if thread limit reached
          await semaphore.WaitAsync();
          string proxyIP = proxy.IPAddress;
          int port = proxy.Port;
          tasks.Add(Task.Run(() => CheckProxyServer(proxyIP, port, Interlocked.Increment(ref currentThreadNumber)))
            .ContinueWith(
              (task) =>
              {
                ProxyAddress result = task.Result;
                // Method call must be thread-safe!
                UpdateProxyDbRecord(result.IPAddress, result.OnlineStatus);
                Interlocked.Decrement(ref currentThreadNumber);
                // Allow to start next thread if thread limit was reached
                semaphore.Release();
              },
              TaskContinuationOptions.OnlyOnRanToCompletion));
        }
        // Asynchronously wait until all tasks are completed
        // to prevent premature disposal of semaphore
        await Task.WhenAll(tasks);
      }
    }

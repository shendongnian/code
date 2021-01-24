    private async Task CheckProxyServerAsync(IEnumerable<object> listProxies)
    {
      var tasks = new List<Task>();
      int nCurrentThread = 0;
      int nThreadsNum = 8;
      using (semaphore = new SemaphoreSlim(nThreadsNum, nThreadsNum))
      {
        for (int i = 0; i < listProxies.Count(); i++)
        {
          // Asynchronously wait until thread is available if thread limit reached
          await semaphore.WaitAsync();
          string strProxyIP = listProxies[i].sIPAddress;
          int nPort = listProxies[i].nPort;
          nCurrentThread++;
          tasks.Add(Task.Run(() => CheckProxyServer(strProxyIP, nPort, nCurrentThread))
            .ContinueWith(
              (task) =>
              {
                ProxyAddress result = task.Result;
                // Method call must be thread-safe!
                UpdateProxyDBRecord(result.sIPAddress, result.bOnlineStatus);
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

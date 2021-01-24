    private async Task CheckProxyServerAsync(IEnumerable<object> listProxies)
    {
      var tasks = new List<Task>();
      int nCurrentThread = 0;
      int nThreadsNum = 8;
      using (semaphore = new SemaphoreSlim(nThreadsNum, nThreadsNum))
      {
        for (int i = 0; i < listProxies.Count(); i++)
        {
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
                semaphore.Release();
              },
              TaskContinuationOptions.OnlyOnRanToCompletion));
        }
        await Task.WhenAll(tasks);
      }
    }

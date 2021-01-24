    private async Task CheckProxyServerAsync(IEnumerable<object> listProxies)
    {
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
          Task.Run(() => CheckProxyServer(strProxyIP, nPort, nCurrentThread)).ContinueWith(
            (task) =>
            {
              ProxyAddress result = task.Result;
              UpdateProxyDBRecord(result.sIPAddress, result.bOnlineStatus);
              semaphore.Release();
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);
        }
      }
    }

    private async Task CheckProxyServerAsync(IEnumerable<ProxyInfo> listProxies)
    {
      var pipe = new BlockingCollection<ProxyInfo>();
      int nThreadsNum = 8;
      var tasks = new List<Task>();
      for (int nCurrentThread = 0; nCurrentThread < nThreadsNum; nCurrentThread++)
      {
        tasks.Add(
          Task.Run(() => ConsumeServerData(pipe, nCurrentThread))
            .ContinueWith(
              async (task) =>
              {
                UpdateProxyDBRecord(semaphore.CurrentCount, task.Result);
                semaphore.Release();
              },
              TaskContinuationOptions.OnlyOnRanToCompletion));
      }
      listProxies.ToList().ForEach(pipe.Add);
      pipe.CompleteAdding();
      await Task.WhenAll(tasks);
    }
    private void ConsumeServerData(BlockingCollection<ProxyInfo> listProxiesPipe, int nCurrentThread)
    {
      while (!listProxiesPipe.IsCompleted)
      {
        if (listProxiesPipe.TryTake(out ProxyInfo proxy))
        {
          int nPort = proxy.nPort;
          string strProxyIP = proxy.sIPAddress;
          CheckProxyServer(strProxyIP, nPort, nCurrentThread);
        }
      }
    }

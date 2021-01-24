    private async Task CheckProxyServerAsync(IEnumerable<ProxyInfo> listProxies)
    {
      var pipe = new BlockingCollection<ProxyInfo>();
      int nThreadsNum = 8;
      var tasks = new List<Task>();
      for (int nCurrentThread = 0; nCurrentThread < nThreadsNum; nCurrentThread++)
      {
        tasks.Add(
          Task.Run(() => ConsumeProxyInfo(pipe, nCurrentThread)));
      }
      listProxies.ToList().ForEach(pipe.Add);
      pipe.CompleteAdding();
      await Task.WhenAll(tasks);
    }
    private void ConsumeProxyInfo(BlockingCollection<ProxyInfo> listProxiesPipe, int nCurrentThread)
    {
      while (!listProxiesPipe.IsCompleted)
      {
        if (listProxiesPipe.TryTake(out ProxyInfo proxy))
        {
          int nPort = proxy.nPort;
          string strProxyIP = proxy.sIPAddress;
          ProxyAddress result = CheckProxyServer(strProxyIP, nPort, nCurrentThread); 
          UpdateProxyDBRecord(result.sIPAddress, result.bOnlineStatus);
        }
      }
    }

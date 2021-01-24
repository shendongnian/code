    // Uses a fixed number of same threads
    private async Task CheckProxyServerAsync(IEnumerable<ProxyInfo> proxies)
    {
      var pipe = new BlockingCollection<ProxyInfo>();
      int maxNumberOfThreads = 8;
      var tasks = new List<Task>();
      // Create all threads (count == maxNumberOfThreads)
      for (int currentThreadNumber = 0; currentThreadNumber < maxNumberOfThreads; currentThreadNumber++)
      {
        tasks.Add(
          Task.Run(() => ConsumeProxyInfo(pipe, currentThreadNumber)));
      }
      proxies.ToList().ForEach(pipe.Add);
      pipe.CompleteAdding();
      await Task.WhenAll(tasks);
    }
    private void ConsumeProxyInfo(BlockingCollection<ProxyInfo> proxiesPipe, int currentThreadNumber)
    {
      while (!proxiesPipe.IsCompleted)
      {
        if (proxiesPipe.TryTake(out ProxyInfo proxy))
        {
          int port = proxy.Port;
          string proxyIP = proxy.IPAddress;
          ProxyAddress result = CheckProxyServer(proxyIP, port, currentThreadNumber); 
          // Method call must be thread-safe!
          UpdateProxyDbRecord(result.IPAddress, result.OnlineStatus);
        }
      }
    }

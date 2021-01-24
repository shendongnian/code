    class ProxyChecker
    {
        private ConcurrentQueue<ProxyInfo> _masterQueue = new ConcurrentQueue<ProxyInfo>();
        public ProxyChecker(IEnumerable<ProxyInfo> listProxies)
        {
            foreach (var proxy in listProxies)
            {
                _masterQueue.Enqueue(proxy);
            }
        }
        public async Task RunChecks(int maximumConcurrency)
        {
            var count = Math.Max(maximumConcurrency, _masterQueue.Count);
            var tasks = Enumerable.Range(0, count).Select( i => WorkerTask() ).ToList();
            await Task.WhenAll(tasks);
        }
        private async Task WorkerTask()
        {
            ProxyInfo proxyInfo;
            while ( _masterList.TryDequeue(out proxyInfo))
            {
                DoTheTest(proxyInfo.IP, proxyInfo.Port)
            }
        }
    } 
         

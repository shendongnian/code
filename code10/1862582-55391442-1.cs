    _httpClientPool = new LimitedPool<httpclient>(
    CreateHttpClient, client => client.Dispose(), HttpClientLifetime);
    
    using (var httpClientContainer = _httpClientPool.Get())
    { ... use httpClientContainer.Value ... }
    

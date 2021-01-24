    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
        IApplicationLifetime lifetime, IDistributedCache cache)
    {
        lifetime.ApplicationStarted.Register(() =>
        {
            var currentTimeUTC = DateTime.UtcNow.ToString();
            var encodedCurrentTimeUTC = Encoding.UTF8.GetBytes(currentTimeUTC);
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromHours(1));
            cache.Set("cachedTimeUTC", encodedCurrentTimeUTC, options);
        });

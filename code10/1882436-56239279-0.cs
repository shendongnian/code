        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        public async Task<string> GetOrCreateAsync(Func<Task<TokenResponse>> getToken)
        {
            string token = Get();
            if (token == null)
            {
                await _semaphore.WaitAsync();
                try
                {
                    token = Get();
                    if (token == null)
                    {
                        var data = await getToken();
                        Set(data);
                        token = data.AccessToken;
                    }
                }
                finally
                {
                    _semaphore.Release();
                }
            }
            return token;
        }

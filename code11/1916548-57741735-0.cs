    public class JWTTokenManager
    {
        private Task<string> tokenTask;
        private readonly object sync = new object();
    
        public Task<string> GetTokenAsync()
        {
            lock (sync)
            {
                if (tokenTask.IsCompleted && !IsTokenValid(tokenTask.Result))
                {
                    tokenTask = GetNewTokenAsync();
                }
    
                return tokenTask;
            }
        }
    }

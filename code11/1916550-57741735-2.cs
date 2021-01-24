    public class JWTTokenManager
    {
        private Task<string> tokenTask;
        private readonly object sync = new object();
    
        public Task<string> GetTokenAsync()
        {
            var currentTokenTask = Volatile.Read(ref tokenTask);
            if (currentTokenTask .IsCompleted && !IsTokenValid(currentTokenTask .Result))
            {
                currentTokenTask = GetNewTokenAsync();
                Volatile.Write(ref tokenTask, currentTokenTask);
            }
    
            return currentTokenTask ;
        }
    }

    class Controller
    {
        private static ConcurrentDictionary<int, SemaphoreSlim> semaphores = new ConcurrentDictionary<int, SemaphoreSlim>();
        
        public async Task<int> DoStuff(int entityId)
        {
            SemaphoreSlim sem = semaphores.GetOrAdd(entityId, ent => new SemaphoreSlim(0, 1));
            await sem.WaitAsync();
            try
            {
                //do real stuff
            }
            finally
            {
                sem.Release();
            }
        }
    }

    public class Test
    {
        private static readonly SemaphoreLocker _locker = new SemaphoreLocker();
        public async Task DoTest()
        {
            await _locker.LockAsync(async () =>
            {
                // [asyn] calls can be used within this block 
                // to handle a resource by one thread. 
            });
        }
    }

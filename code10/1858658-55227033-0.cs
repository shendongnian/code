    public class AsyncCache
    {
        private Dictionary<Guid, Task<string>> _cache;
            
        public Task<string> GetAsync(Guid guid)
        {
            if (_cache.TryGetValue(guid, out var task))
            {
                // The value is either there or already queued
                return task;
            }
        
            var tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
        
            _queue.Enqueue(() => {
               var result = LoadResult();
               tcs.TrySetValue(result);
            });
            
            _cache.Add(guid, tcs.Task);
            
            return tcs.Task;            
        }
    }

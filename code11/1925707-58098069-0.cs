    public static class TaskExt
    {
        public static async Task<T> AwaitSafe<T>(this Task<T> task, Action<Exception> handle)
        {
            T data = default(T);
            try
            {
                data = await task;
            }
            catch (Exception ex)
            {
                handle.Invoke(ex);
            }
    
            return data;
        }
    }

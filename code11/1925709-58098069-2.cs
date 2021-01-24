    public static class TaskExt
    {
        public static async Task<T> AwaitSafe<T, TException>(this Task<T> task, Action<TException> handle)
            where TException: Exception
        {
            T data = default(T);
            try
            {
                data = await task;
            }
            catch (TException ex)
            {
                handle.Invoke(ex);
            }
    
            return data;
        }
    }

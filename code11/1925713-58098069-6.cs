    public struct Result<TResult>
    {
        public static Result<TResult> Ok(TResult data) => new Result<TResult>(data, true);
        public static Result<TResult> Error() => new Result<TResult>(default(TResult), false);
    
        private Result(TResult data, bool success)
        {
            Data = data;
            Success = success;
        }
    
        public bool Success { get; }
        public TResult Data { get; }
    }
    
    public static class TaskExt
    {
        public static async Task<Result<T>> AwaitSafe<T, TException>(this Task<T> task, Action<TException> handle)
            where TException : Exception
        {
            var result = Result<T>.Error();
            try
            {
                result = Result<T>.Ok(await task);
            }
            catch (TException ex)
            {
                handle.Invoke(ex);
            }
    
            return result;
        }
    }

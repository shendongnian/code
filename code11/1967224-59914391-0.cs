csharp
    public class Attempt<TResult>
    {
        private Attempt(TResult result, bool success, Exception exception)
        {
            Result = result;
            Success = success;
            Exception = exception;
        }
        public TResult Result { get; }
        public bool Success { get; }
        public Exception Exception { get; }
        public static async Task<Attempt<TResult>> ResultAsync(Task<TResult> task)
        {
            try
            {
                TResult result = await task;
                return new Attempt<TResult>(result, true, null);
            }
            catch (Exception ex)
            {
                return new Attempt<TResult>(default, false, ex);
            }
        }
    }
    public class AttemptsTests
    {
        private static readonly List<string> SuccessList = new List<string> { "a", "b", "c" };
        /// <summary>
        /// Simple demonstrator for a short handler making use of the Attempt class,
        /// called with flag equal to true or false to simulate success or failure
        /// of the MakeAttemptAsync method.
        /// </summary>
        private static async Task<Attempt<List<string>>> HandleAsync(bool flag)
        {
            Task<List<string>> task = MakeAttemptAsync(flag);
            return await Attempt<List<string>>.ResultAsync(task);
        }
        /// <summary>
        /// Simple dummy method that returns a successful or failed task.
        /// </summary>
        private static Task<List<string>> MakeAttemptAsync(bool flag)
        {
            return flag
                ? Task.FromResult(SuccessList)
                : Task.FromException<List<string>>(new Exception("Failed attempt"));
        }
        [Fact]
        public async Task HandleAsync_Failure_ExceptionReturned()
        {
            Attempt<List<string>> attempt = await HandleAsync(false);
            Assert.False(attempt.Success);
            Assert.Null(attempt.Result);
            Assert.Equal("Failed attempt", attempt.Exception.Message);
        }
        [Fact]
        public async Task HandleAsync_Success_ListReturned()
        {
            Attempt<List<string>> attempt = await HandleAsync(true);
            Assert.True(attempt.Success);
            Assert.Equal(SuccessList, attempt.Result);
            Assert.Null(attempt.Exception);
        }
    }

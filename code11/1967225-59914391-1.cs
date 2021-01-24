csharp
    /// <summary>
    /// Utility class that helps shorten the calling code.
    /// </summary>
    public static class Attempt
    {
        public static async Task<Attempt<TResult>> ResultAsync<TResult>(Task<TResult> task)
        {
            return await Attempt<TResult>.ResultAsync(task);
        }
        public static Attempt<TResult> ResultOf<TResult>(Func<TResult> func)
        {
            return Attempt<TResult>.ResultOf(func);
        }
    }
    /// <summary>
    /// Represents a successful or failed attempt.
    /// </summary>
    /// <typeparam name="TResult">The result type.</typeparam>
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
        public static Attempt<TResult> ResultOf(Func<TResult> func)
        {
            try
            {
                TResult result = func();
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
        /// Simple demonstrator for a short, synchronous handler making use of the
        /// Attempt class, called with flag equal to true or false to simulate
        /// success or failure of the MakeAttemptAsync method.
        /// </summary>
        private static Attempt<List<string>> Handle(bool flag)
        {
            return Attempt.ResultOf(() => MakeAttempt(flag));
        }
        /// <summary>
        /// Simple demonstrator for a short, asynchronous handler making use of the
        /// Attempt class, called with flag equal to true or false to simulate
        /// success or failure of the MakeAttemptAsync method.
        /// </summary>
        private static async Task<Attempt<List<string>>> HandleAsync(bool flag)
        {
            Task<List<string>> task = MakeAttemptAsync(flag);
            return await Attempt.ResultAsync(task);
        }
        /// <summary>
        /// Simple dummy method that returns a List or throws an exception.
        /// </summary>
        private static List<string> MakeAttempt(bool flag)
        {
            return flag
                ? SuccessList
                : throw new Exception("Failed attempt");
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
        public void Handle_Failure_ExceptionReturned()
        {
            Attempt<List<string>> attempt = Handle(false);
            Assert.False(attempt.Success);
            Assert.Null(attempt.Result);
            Assert.Equal("Failed attempt", attempt.Exception.Message);
        }
        [Fact]
        public void Handle_Success_ListReturned()
        {
            Attempt<List<string>> attempt = Handle(true);
            Assert.True(attempt.Success);
            Assert.Equal(SuccessList, attempt.Result);
            Assert.Null(attempt.Exception);
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
### Update 2020-01-26
I amended the above example by adding a new static `Attempt` utility class that helps shorten the calling code. For example, instead of writing:
    return await Attempt<List<string>>.ResultAsync(task);
you can write:
    return await Attempt.ResultAsync(task);
as `TResult` is implicit from the `task` parameter. Secondly, I added a `ResutOf` method that takes a `Func<TResult>`, so you don't need to use `TaskFromResult` to turn a synchronous result into a task.

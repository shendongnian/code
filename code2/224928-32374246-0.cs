    /// <summary>
    /// Compose tasks without starting them.
    /// Waiting on the returned task waits for both components to complete.
    /// An exception in the first task will stop the second task running.
    /// </summary>
    public static class TaskExtensions
    {
        public static Task FollowedBy(this Task first, Task second)
        {
            return FollowedBy(first,
                () =>
                {
                    second.Start();
                    second.Wait();
                });
        }
        public static Task FollowedBy(this Task first, Action second)
        {
            return new Task(
                () =>
                {
                    if (first.Status == TaskStatus.Created) first.Start();
                    first.Wait();
                    second();
                });
        }
        public static Task FollowedBy<T>(this Task first, Task<T> second)
        {
            return new Task<T>(
                () =>
                {
                    if (first.Status == TaskStatus.Created) first.Start();
                    first.Wait();
                    second.Start();
                    return second.Result;
                });
        }
        public static Task FollowedBy<T>(this Task<T> first, Action<T> second)
        {
            return new Task(
                () =>
                {
                    if (first.Status == TaskStatus.Created) first.Start();
                    var firstResult = first.Result;
                    second(firstResult);
                });
        }
        public static Task<TSecond> FollowedBy<TFirst, TSecond>(this Task<TFirst> first, Func<TFirst, TSecond> second)
        {
            return new Task<TSecond>(
                () =>
                {
                    if (first.Status == TaskStatus.Created) first.Start();
                    return second(first.Result);
                });
        }
    }

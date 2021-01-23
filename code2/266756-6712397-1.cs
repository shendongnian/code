    public static class AsyncHelper
    {
        public static Task<T> Invoke<T>(Func<TaskCompletionSource<T>, IEnumerable<Task>> method)
        {
            var context = SynchronizationContext.Current;
            var tcs = new TaskCompletionSource<T>();
            var steps = method(tcs);
            var enumerator = steps.GetEnumerator();
            bool more = enumerator.MoveNext();
            Task.Factory.StartNew(
                () =>
                {
                    while (more)
                    {
                        enumerator.Current.Wait();
                        if (context != null)
                        {
                            context.Send(
                                state =>
                                {
                                    more = enumerator.MoveNext();
                                }
                                , null);
                        }
                        else
                        {
                            enumerator.MoveNext();
                        }
                    }
                }).ContinueWith(
                (task) =>
                {
                    if (!tcs.Task.IsCompleted)
                    {
                        tcs.SetResult(default(T));
                    }
                });
            return tcs.Task;
        }
    }

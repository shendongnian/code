    public static class Blindly
    {
        private static readonly Action<Task> DefaultErrorContinuation =
            t =>
            {
                try { t.Wait(); }
                catch {}
            };
        public static void Run(Action action, Action<Exception> handler = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            var task = Task.Run(action);  // Adapt as necessary for .NET 4.0.
            if (handler == null)
            {
                task.ContinueWith(
                    DefaultErrorContinuation,
                    TaskContinuationOptions.ExecuteSynchronously |
                    TaskContinuationOptions.OnlyOnFaulted);
            }
            else
            {
                task.ContinueWith(
                    t => handler(t.Exception.GetBaseException()),
                    TaskContinuationOptions.ExecuteSynchronously |
                    TaskContinuationOptions.OnlyOnFaulted);
            }
        }
    }

    public static class STATask
    {
        /// <summary>
        /// Similar to Task.Run(), except this creates a task that runs on a thread
        /// in an STA apartment rather than Task's MTA apartment.
        /// </summary>
        /// <typeparam name="TResult">The return type of the task.</typeparam>
        /// <param name="function">The work to execute asynchronously.</param>
        /// <returns>A task object that represents the work queued to execute on an STA thread.</returns>
        public static Task<TResult> Run<TResult>([NotNull] Func<TResult> function)
        {
            var tcs = new TaskCompletionSource<TResult>();
            var thread = new Thread(() =>
            {
                try
                {
                    tcs.SetResult(function());
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            return tcs.Task;
        }
        /// <summary>
        /// Similar to Task.Run(), except this creates a task that runs on a thread
        /// in an STA apartment rather than Task's MTA apartment.
        /// </summary>
        /// <param name="action">The work to execute asynchronously.</param>
        /// <returns>A task object that represents the work queued to execute on an STA thread.</returns>
        public static Task Run([NotNull] Action action)
        {
            var tcs = new TaskCompletionSource<object>(); // Return type is irrelevant for an Action.
            var thread = new Thread(() =>
            {
                try
                {
                    action();
                    tcs.SetResult(null); // Irrelevant.
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            return tcs.Task;
        }
    }

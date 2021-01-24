    class Worker<TResult> : IDisposable
    {
        private BlockingCollection<TaskCompletionSource<TResult>> _blockingCollection
            = new BlockingCollection<TaskCompletionSource<TResult>>();
        public Worker()
        {
            var thread = new Thread(MainLoop);
            thread.IsBackground = true;
            thread.Start();
        }
        private void MainLoop()
        {
            foreach (var tcs in _blockingCollection.GetConsumingEnumerable())
            {
                var job = (Func<TResult>)tcs.Task.AsyncState;
                try
                {
                    var result = job.Invoke();
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            }
        }
        public Task<TResult> DoWorkAsync(Func<TResult> job)
        {
            var tcs = new TaskCompletionSource<TResult>(job,
                TaskCreationOptions.RunContinuationsAsynchronously);
            _blockingCollection.Add(tcs);
            return tcs.Task;
        }
        public TResult DoWork(Func<TResult> job) // Synchronous call
        {
            var task = DoWorkAsync(job);
            try { task.Wait(); } catch { } // Swallow the AggregateException
            // Throw the original exception, if occurred, preserving the stack trace
            if (task.IsFaulted) ExceptionDispatchInfo.Capture(task.Exception.InnerException).Throw();
            return task.Result;
        }
        public void Dispose()
        {
            _blockingCollection.CompleteAdding();
        }
    }

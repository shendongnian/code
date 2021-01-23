        public static async Task<T> CancelAfterAsync<T>( this Func<CancellationToken,Task<T>> actionAsync, int timeoutMilliseconds)
        {
            if (timeoutMilliseconds < 0 || (timeoutMilliseconds > 0 && timeoutMilliseconds < 100)) { throw new ArgumentOutOfRangeException(); }
            var taskCts = new CancellationTokenSource();
            var timerCts = new CancellationTokenSource();
            Task<T> task = actionAsync(taskCts.Token);
            if (await Task.WhenAny(task, Task.Delay(timeoutMilliseconds, timerCts.Token)) == task) {
                timerCts.Cancel(); // task completed, get rid of timer
            } else {
                taskCts.Cancel(); // timer completed, get rid of task
            }
            return await task; // test for exceptions or task cancellation
        }

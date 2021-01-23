        public static async Task<T> CancelAfterAsync<T>(this Task<T> task, int timeoutMilliseconds, CancellationTokenSource taskCts)
        {
            if (timeoutMilliseconds < 0 || (timeoutMilliseconds > 0 && timeoutMilliseconds < 100)) { throw new ArgumentOutOfRangeException(); }
            var timerCts = new CancellationTokenSource();
            if (await Task.WhenAny(task, Task.Delay(timeoutMilliseconds, timerCts.Token)) == task) {
                timerCts.Cancel(); // task completed, get rid of timer
            } else {
                taskCts.Cancel(); // timer completed, get rid of task
            }
            return await task; // test for exceptions or task cancellation
        }

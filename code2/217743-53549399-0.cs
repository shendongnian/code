        public static async Task<bool> TimedOutAsync(this Task task, int timeoutMilliseconds)
        {
            if (timeoutMilliseconds < 0 || (timeoutMilliseconds > 0 && timeoutMilliseconds < 100)) { throw new ArgumentOutOfRangeException(); }
            if (timeoutMilliseconds == 0) {
                return !task.IsCompleted; // timed out if not completed
            }
            var cts = new CancellationTokenSource();
            if (await Task.WhenAny( task, Task.Delay(timeoutMilliseconds, cts.Token)) == task) {
                cts.Cancel(); // task completed, get rid of timer
                await task; // test for exceptions or task cancellation
                return false; // did not timeout
            } else {
                return true; // did timeout
            }
        }

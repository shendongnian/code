        public static Task StartDelayTask(int delay, CancellationToken token)
        {
            var source = new TaskCompletionSource<Object>();
            Timer timer = null;
            
            timer = new Timer(s =>
            {
                source.TrySetResult(null);
                timer.Dispose();
            }, null, delay, -1);
            token.Register(() => source.TrySetCanceled());
            return source.Task;
        }
        public static Task ContinueAfterDelay(this Task task, int delay, Action<Task> continuation, CancellationToken token)
        {
            var source = new TaskCompletionSource<Object>();
            Timer timer = null;
            var startTimer = new Action<Task>(t =>
            {
                timer = new Timer(s =>
                {
                    source.TrySetResult(null);
                    timer.Dispose();
                },null,delay,-1);
            });
            task.ContinueWith(startTimer, token, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Current);
            token.Register(() => source.TrySetCanceled());
            return source.Task.ContinueWith(continuation, token);
        }

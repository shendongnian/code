    public static class TaskRefBoolCancellable
    {
        public static T SynchronousAwait<T>(Func<CancellationToken, Task<T>> taskToRun, ref bool isCancelled)
        {
            using (var cts = new CancellationTokenSource())
            {
                var runningTask = taskToRun(cts.Token);
                while (!runningTask.IsCompleted)
                {
                    if (isCancelled)
                        cts.Cancel();
                    Thread.Sleep(100);
                }
                return runningTask.Result;
            }
        }
    }
    void Method(ref bool isCancelled)
    {
        while (!isCancelled)
        {
            ...
            DoThis();
            var result = TaskRefBoolCancellable.SynchronousAwait(DoTheNewThingAsync, ref isCancelled);
            DoThat();
            ...
        }
    }

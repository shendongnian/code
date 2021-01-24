        private static Task _runningTask;
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            _runningTask = ExecuteQueuePolling(cts.Token);
            WaitForCancel(cts);
        }
        private static void WaitForCancel(CancellationTokenSource cts)
        {
            var spinner = new SpinWait();
            while (!cts.IsCancellationRequested
                && _runningTask.Status == TaskStatus.Running) spinner.SpinOnce();
        }
        private static Task ExecuteQueuePolling(CancellationToken cancellationToken)
        {
            var t = new Task(() =>
            {
                while (!cancellationToken.IsCancellationRequested) 
                    ; // your code
                if (cancellationToken.IsCancellationRequested)
                    throw new OperationCanceledException();
            }, cancellationToken, TaskCreationOptions.LongRunning);
            t.Start();
            return t;
        }

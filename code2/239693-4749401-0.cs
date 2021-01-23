    public sealed class AbandonableTask
    {
        private readonly CancellationToken _token;
        private readonly Action _beginWork;
        private readonly Action _blockingWork;
        private readonly Action<Task> _afterComplete;
        private AbandonableTask(CancellationToken token, Action beginWork, Action blockingWork, Action<Task> afterComplete)
        {
            if (blockingWork == null) throw new ArgumentNullException("blockingWork");
            _token = token;
            _beginWork = beginWork;
            _blockingWork = blockingWork;
            _afterComplete = afterComplete;
        }
        private void RunTask()
        {
            if (_beginWork != null)
                _beginWork();
            var innerTask = new Task(_blockingWork, _token, TaskCreationOptions.LongRunning);
            innerTask.Start();
            innerTask.Wait(_token);
            if (innerTask.IsCompleted && _afterComplete != null)
            {
                _afterComplete(innerTask);
            }
        }
        public static Task Start(CancellationToken token, Action blockingWork, Action beginWork = null, Action<Task> afterComplete = null)
        {
            if (blockingWork == null) throw new ArgumentNullException("blockingWork");
            var worker = new AbandonableTask(token, beginWork, blockingWork, afterComplete);
            var outerTask = new Task(worker.RunTask, token);
            outerTask.Start();
            return outerTask;
        }
    }

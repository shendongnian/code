    class OutputRetriever
    {
        private readonly ConcurrentBag<string> _allMessages = new ConcurrentBag<string>();
        private readonly TaskCompletionSource<string[]> _taskSource
            = new TaskCompletionSource<string[]>();
        // Note: this method is not async anymore
        public Task<string[]> GetAllOutput()
        {
            // We just return a task that can be awaited
            return _taskSource.Task;
        }
        void ConsoleDataReceived(object sender, DataReceivedEventArgs e)
        {
            _allMessages.Add(e?.Data);
            if (e?.Data == "success")
            {
                // Here we notify that the task is completed by setting the result
                _taskSource.SetResult(_allMessages.ToArray());
            }
        }
    }

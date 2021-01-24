    private object _locker = new object();
    private void Print(string message)
    {
        lock (_locker)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Dispatcher.Invoke(() =>
            {
                Output.AppendText($"[{ threadId }] { message }\n");
            });
        }
    }

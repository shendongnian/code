    private static object locker = new object();
    private void Print(string message)
    {
        lock (locker)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Dispatcher.Invoke(() =>
            {
                Output.AppendText($"[{ threadId }] { message }\n");
            });
        }
    }

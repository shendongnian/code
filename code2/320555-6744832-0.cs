    public void MoreData(Data example)
    {
        var queueWasEmpty = _queue.IsEmpty;
        _queue.Enqueue(example);
        if (queueWasEmpty) {
            _queueNotifier.Set();
        }
    }
    
    private void _SimpleThreadWorker()
    {
        while (_socket.Connected)
        {
            _queueNotifier.WaitOne();
            Data data;
            while(!queue.IsEmpty) {
                if (_queue.TryDequeue(out data))
                {
                    //handle the data
                }
            }
        }
    }

    public TResult Value
    {
        get
        {
            if (!IsCompleted)
            {
                _asyncResult.AsyncWaitHandle.WaitOne();
                _lock.WaitOne();
            }
            return _value;
        }
    }

    void DoSome()
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(delegate { RunMe(); ReturnTo(); }));
    }
    void RunMe() { }
    void ReturnTo() { }

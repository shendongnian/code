    public void RefreshData()
    {
        Task<MyData>.Factory.StartNew(() => GetData())
            .ContinueWith(t => {/* Do something with t.Result */}, Scheduler);
    }

    public IObservable<string> MessageStream
    {
        get
        {
            return this.stream.ObserveOn(Scheduler.ThreadPool).AsObservable();
        }
    }

    ...
    Monitor md = new Monitor(this.Dispatcher);
    ...
    public Monitor(Dispatcher dispatcher)
    {
         _dispatcher = dispatcher;
    }
    ...
    public longwork() {
        _dispatcher.BeginInvoke((Action)(()=>listOfPeople.Add(new People()));
        Thread.Sleep(10000);
    }

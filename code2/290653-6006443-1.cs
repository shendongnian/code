    public static IObservable<string> GetOutput(this Process that)
    {
           return Observable.FromEventPattern<DataReceivedEventArgs>(that, "OutputDataReceived")
                            .Select(ep => ep.EventArgs.Data);
    }

    public static IObservable<string> GetOutput(this Process that)
    {
        return Observable.FromEvent<DataReceivedEventArgs>(that, "OutputDataReceived")
                         .Select(ep => ep.EventArgs.Data);
    }

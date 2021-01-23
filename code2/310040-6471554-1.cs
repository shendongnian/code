    public event EventHander<ProgressEventArgs> ProgessEvent;
    public static void Function2(var something)
    {
        progressbar.value++;
        OnRaiseProgressEvent(new ProgressEventArgs(1);
    }
    
    protected virtual void OnRaiseProgressEvent(ProgressEventArgs e)
    {
        EventHandler<ProgessEventArgs> handler = ProgressEvent;
        if(handler != null)
        {
            //this is what actually raises the event.
            handler(this, e);
        }
    }

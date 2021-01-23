    protected override void OnTextChanged (EventArgs eventArgs)
    {
        System.Diagnostics.Trace.WriteLine("OnTextChanged(): eventArgs: " + eventArgs);  
        base.OnTextChanged(eventArgs);
    }

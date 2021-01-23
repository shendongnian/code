    public MainForm()
    {
    var tl - new MyTraceListener(this.textBox);
    Trace.Listeners.Add(tl);
    }

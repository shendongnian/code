    [SuppressMessage("Microsoft.Reliability",
                     "CA2000:DisposeObjectsBeforeLosingScope",
                     Justification = "Your reasons go here")]
    public YourClass(IDisposable obj) : base(obj)
    {
    }

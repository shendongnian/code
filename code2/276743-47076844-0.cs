    public bool MyIsDisposed { get; private set; }
    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        MyIsDisposed = true;
     }
}`

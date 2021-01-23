    public event EventHandler SomethingHappened;
    protected void OnSomethingHappend(EventArgs e)
    {
        if (SomethingHappened != null)
            SomethingHappened(this, e);
    }

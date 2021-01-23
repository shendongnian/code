    public void AttachToAEvent()
    {
        _foo.AEvent += new EventHandler(this.Handler);
    }
    
    [CompilerGenerated]
    private void Handler(object sender, EventArgs e)
    {
        this.UseBar(this._bar);
    }

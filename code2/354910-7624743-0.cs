    public void Start()
    {
        this.pollTimer.Elapsed += pollTimer_elapsed
        this.pollTimer.Start();
    }
    
    private void pollTimer_elapsed(object sender, ElapsedEventArgs e)
    {
        var han = this.Elapsed;
        if (han != null)
            han(this, e); // Fire the Elapsed event, passing 'this' Poll as the sender
    }

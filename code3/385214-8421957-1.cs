    public delegate void IsReadyForUseEventHandler(object sender, IsReadyForUseEventArgs e);
    public event IsReadyForUseEventHandler IsReadyForUse;
    void OnIsReadyForUse(IsReadyForUseEventArgs e)
    {
        var handler = IsReadyForUse;
        if (handler != null)
        {
            handler(this, e);
        }
    }

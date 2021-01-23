    // A delegate type for hooking up change notifications.
    public delegate void ChangedEventHandler(object sender, EventArgs e);
    //the actual event
    public event ChangedEventHandler Changed;
    // Method to raise/fire the Changed event. Call this whenever something changes
    protected virtual void OnChanged(EventArgs e) 
    {
        if (Changed != null)
           Changed(this, e);
    }
    public void SetValue(string aValue)
    {
        txtValue.Text = aValue;
        OnChanged(EventArgs.Empty);
    }

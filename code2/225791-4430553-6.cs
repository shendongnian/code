    // A delegate type for hooking up change notifications.
    // This is _what kind_ of event you want. It sets the signature your event handler methods must have.
    public delegate void ChangedEventHandler(object sender, EventArgs e);
    //the actual event
    public event ChangedEventHandler Changed;
    // Method to raise/fire the Changed event. Call this whenever something changes
    protected virtual void OnChanged(EventArgs e) 
    {
        ChangedEventHandler handler = Changed;
        if (handler != null) handler(this, e);
    }
    //and update your existing SetValue() function like so:
    public void SetValue(string aValue)
    {
        txtValue.Text = aValue;
        OnChanged(EventArgs.Empty);
    }

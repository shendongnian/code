    public static event EventHandler ObjectWasCreated;
    public static event EventHandler ObjectWasDeleted;  
    void DispatchEvent(EventHandler handler, object sender, EventArgs args) 
    {
        if (handler != null)
        {
            // ...
            handler(sender, args);
        }
    }

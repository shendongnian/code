    public enum MyEvents
    {
        Event1
    }
    
    public class CustomEventArgs : EventArgs
    {
        public MyEvents MyEvents { get; set; }
    }
    
            
    private EventHandler<CustomEventArgs> onTrigger;
    
    public event EventHandler<CustomEventArgs> Trigger
    {
        add
        {
            onTrigger += value;
        }
        remove
        {
            onTrigger -= value;
        }
    }
    
    protected void OnTrigger(CustomEventArgs e)
    {
        if (onTrigger != null)
        {
            onTrigger(this, e);
        }
    }

    public class CustomEventArgs : EventArgs
        {
            public GlobalDebugMonitorControl Control { get; set; }
    
            public CustomEventArgs(GlobalDebugMonitorControl control) 
            {
                this.Control = control;
            }
        }

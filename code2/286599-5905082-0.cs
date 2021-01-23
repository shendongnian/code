    private System.Threading.SynchronizationContext syncContext;
    
    public Form1()
    {
        InitializeComponent();
        syncContext = System.Threading.SynchronizationContext.Current;
    }
    
    private void UpdateControlsOnTheUIThread()
    {
        syncContext.Send(x => 
        {
            // Do sth here..
            myControl.Property = newValue;
        }, null);
    }
 

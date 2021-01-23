    public bool Modified { get; set; }
    private bool enabled;
    public bool Enabled
    {
        get { return enabled; }
 
        set
        {
            if (enabled != value)
            {
                Modified = true;
                enabled = value;
            }
        }
    }

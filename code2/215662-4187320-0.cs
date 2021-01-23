    private float mass;
    public float Mass
    {
        get
        {
            return this.mass;
        }
    
        set
        {
            if (value >= 0.0F)
            {
                throw new ArgumentOutOfRangeException("Mass cannot be zero or negative.");
            }
    
            if (this.mass != value)
            {
                this.mass = value;
                OnMassChanged(EventArgs.Empty);
            }
        }
    }
    
    public event EventHandler MassChanged;
    
    private virtual void OnMassChanged(EventArgs args)
    {
        var handler = this.MassChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }

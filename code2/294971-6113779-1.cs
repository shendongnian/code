    private double xMin = -10;
    [DefaultValue(-10)]
    public double XMin
    {
        get { return xMin; }
        set
        {
            xMin = value;
            this.Invalidate();
        }
    }

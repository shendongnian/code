    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public double XMin
    {
        get { return xMin; }
        set
        {
            xMin = value;
            this.Invalidate();
        }
    }

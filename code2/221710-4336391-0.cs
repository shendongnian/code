    public OrientationProperty Direction
    {
        get
        {
            return _direction;
        }
        set
        {
            _direction = value;
            if (DesignMode)
            {
                Parent.Refresh(); // Refreshes the client area of the parent control
            }
        }
    }
    private OrientationProperty _direction;

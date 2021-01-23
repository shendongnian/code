    public double AirDensity
    {
        get { return _airDensity; }
        set
        {            
            _airDensity = ValidationHelpers.ValidateNonNegative(value,
                                                                "Air density");
        }
    }

    public double? Sigma
    {
        get
        {
            if (XScale == XSCalingType.Sigma)
                return _sigma;
            else
                return null;
        }
        set { _sigma = value;}
    }

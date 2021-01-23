    protected Circle(Circle t)
    {
        CopyFrom(t);
    }
    public override object Clone()
    {
        return new Circle(this);
    }
    protected void CopyFrom(Circle t)
    {
        // Ensure we have something to copy which is also not a self-reference
        if (t == null || object.ReferenceEquals(t, this))
            return;
        // Base
        base.CopyFrom((Shape)t);
        // Derived
        Diameter = t.Diameter;
    }

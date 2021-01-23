    public override bool Equals(object obj)
    {
        if (!(obj is double))
        {
            return false;
        }
        double d = (double) obj;
        return ((d == this) || (IsNaN(d) && IsNaN(this)));
    }

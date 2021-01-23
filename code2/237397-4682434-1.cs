    public override bool Equals(T x, T y)
    {
        if (x != null)
        {
            return ((y != null) && x.Equals(y));
        }
        if (y != null)
        {
            return false;
        }
        return true;
    }

    public override bool Equals(object obj)
    {
        if (obj != null && obj is BaseClass)
        {
            return BusinessId.Equals((obj as BaseClass).BusinessId);
        }
        else
        {
            return false;
        }
    }

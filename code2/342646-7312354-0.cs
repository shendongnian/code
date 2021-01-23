    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 31 + field1.GetHashCode();
        hash = hash * 31 + field2.GetHashCode();
        hash = hash * 31 + field3.GetHashCode();
        ...
        return hash;
    }

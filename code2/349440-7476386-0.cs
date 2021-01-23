    public override int GetHashCode()
    {
        unchecked
        {
            return ((name != null ? name.GetHashCode() : 0)*397) ^ (type != null ? type.GetHashCode() : 0);
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 19;
            foreach (var foo in foos)
            {
                hash = hash * 31 + foo.GetHashCode();
            }
            return hash;
        }
    }

    public override int GetHashCode()
    {
        unchecked  
        {
            int hash = 23;
            // Suitable nullity checks etc, of course :)
            hash = hash * 31 + Start.GetHashCode();
            hash = hash * 31 + End.GetHashCode();
            return hash;
        }
    }

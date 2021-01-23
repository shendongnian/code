    public static bool operator ==(Person lhs, Person rhs)
    {
        // If both are null, or both are same instance, return true.
        if (System.Object.ReferenceEquals(lhs, rhs))
        {
            return true;
        }
        // If one is null, but not both, return false.
        if (((object)lhs == null) || ((object)rhs == null))
        {
            return false;
        }
        // Return true if the fields match:
        return lhs.Equals(rhs);
    }

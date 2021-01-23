    public override int GetHashCode()
    {
        // Unchecked to allow overflow, which is fine
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + (FirstName ?? "").GetHashCode();
            hash = hash * 31 + (LastName ?? "").GetHashCode();
            hash = hash * 31 + (PhoneNumber ?? "").GetHashCode();
            return hash;
        }
    }

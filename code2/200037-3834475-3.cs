    public override int GetHashCode()
    {
        // Unchecked to allow overflow, which is fine
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + (FirstName == null ? 0 : FirstName.GetHashCode());
            hash = hash * 31 + (LastName == null ? 0 : LastName.GetHashCode());
            hash = hash * 31 + (PhoneNumber == null ? 0 : PhoneNumber.GetHashCode());
            return hash;
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + _userName.GetHashCode();
            foreach (string licence in Licences)
            {
                hash = hash * 31 + licences.GetHashCode();
            }
            return hash;
        }
    }

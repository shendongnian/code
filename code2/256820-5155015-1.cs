    public int HashString(string text)
    {
        // TODO: Determine nullity policy.
        unchecked
        {
            int hash = 23;
            foreach (char c in text)
            {
                hash = hash * 31 + c;
            }
            return hash;
        }
    }

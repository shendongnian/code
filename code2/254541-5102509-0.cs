    public int GetUniqueValue(string x, string y)
    {
        unchecked {
            var result = x.GetHashCode() * x.GetHashCode();
            return result;
        }
    }

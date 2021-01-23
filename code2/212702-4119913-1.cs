    public override int GetHashCode()
    {
        int result = 17;
        foreach (byte b in str)
        {
            result = result * 31 + b;
        }
        return result;
    }

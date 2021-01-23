    protected override int GetHashCode()
    {
        unchecked
        {
            return (str1.GetHashCode() * 1369) ^
                   (str2.GetHashCode() * 37) ^ str3.GetHashCode();
        }
    }

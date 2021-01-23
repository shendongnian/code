    public static long GetHashCodeInt64(string input)
    {
        var s1 = input.Substring(0, input.Length / 2);
        var s2 = input.Substring(input.Length / 2);
    
        var x= ((long)s1.GetHashCode()) << 0x20 | s2.GetHashCode();
    
        return x;
    }

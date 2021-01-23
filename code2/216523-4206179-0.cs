    [SecuritySafeCritical]
    public static string Concat(string str0, string str1)
    {
        if (IsNullOrEmpty(str0))
        {
            if (IsNullOrEmpty(str1))
            {
                return Empty;
            }
            return str1;
        }
        if (IsNullOrEmpty(str1))
        {
            return str0;
        }
        int length = str0.Length;
        string dest = FastAllocateString(length + str1.Length);
        FillStringChecked(dest, 0, str0);
        FillStringChecked(dest, length, str1);
        return dest;
    }
 

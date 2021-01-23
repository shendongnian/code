    public static bool EqualsOrdinal(this SecureString text1, SecureString text2, bool ignoreCase = false)
    {
        if (text1 == text2)
            return true;
        if (text1 == null)
            return text2 == null;
        if (text2 == null)
            return false;
        if (text1.Length != text2.Length)
            return false;
        var b1 = IntPtr.Zero;
        var b2 = IntPtr.Zero;
        try
        {
            b1 = Marshal.SecureStringToBSTR(text1);
            b2 = Marshal.SecureStringToBSTR(text2);
            return CompareStringOrdinal(b1, text1.Length, b2, text2.Length, ignoreCase) == CSTR_EQUAL;
        }
        finally
        {
            if (b1 != IntPtr.Zero)
            {
                Marshal.ZeroFreeBSTR(b1);
            }
            if (b2 != IntPtr.Zero)
            {
                Marshal.ZeroFreeBSTR(b2);
            }
        }
    }
    public static bool EqualsOrdinal(this SecureString text1, string text2, bool ignoreCase = false)
    {
        if (text1 == null)
            return text2 == null;
        if (text2 == null)
            return false;
        if (text1.Length != text2.Length)
            return false;
        var b = IntPtr.Zero;
        try
        {
            b = Marshal.SecureStringToBSTR(text1);
            return CompareStringOrdinal(b, text1.Length, text2, text2.Length, ignoreCase) == CSTR_EQUAL;
        }
        finally
        {
            if (b != IntPtr.Zero)
            {
                Marshal.ZeroFreeBSTR(b);
            }
        }
    }
    private const int CSTR_EQUAL = 2;
    [DllImport("kernel32")]
    private static extern int CompareStringOrdinal(IntPtr lpString1, int cchCount1, IntPtr lpString2, int cchCount2, bool bIgnoreCase);
    [DllImport("kernel32")]
    private static extern int CompareStringOrdinal(IntPtr lpString1, int cchCount1, [MarshalAs(UnmanagedType.LPWStr)] string lpString2, int cchCount2, bool bIgnoreCase);

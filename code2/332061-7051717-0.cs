    [DllImport( "my.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode )]
    private static extern void GetMyString(StringBuffer str, int len);
    public string GetMyStringMarshal()
    {
        StringBuffer buffer = new StringBuffer(255);
        GetMyString(buffer, buffer.Capacity);
        return buffer.ToString();
    }

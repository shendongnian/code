    [DllImport(@"MyDLL.dll", CharSet = CharSet.Ansi)]
    private static extern void MyFunction([MarshalAs(UnmanagedType.LPStr)] string input, StringBuilder result);
    
    public static string MyFunctionPublic(string input)
    {
        StringBuilder sb = new StringBuilder(input.Length + 1);
        MyFunction(input, sb);
        return sb.ToString();
    }

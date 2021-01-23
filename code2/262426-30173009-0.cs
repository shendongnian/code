    [DllImport("MyDll.dll")]
    private static extern IntPtr GetSomeText();
    public static string GetAllValidProjects()
    {
        string s = Marshal.PtrToStringAnsi(GetSomeText());
        return s;
    }

    [DllImport("user32.dll", EntryPoint = "GetClassName", ExactSpelling = false,
                CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int _GetClassName(IntPtr hwnd, StringBuilder lpClassName,
                int nMaxCount);
    public static string GetClassName(IntPtr hWnd)
    {
       StringBuilder title = new StringBuilder(MAXTITLE);
       int titleLength = _GetClassName(hWnd, title, title.Capacity + 1);
       title.Length = titleLength;
    
       return title.ToString();
    }

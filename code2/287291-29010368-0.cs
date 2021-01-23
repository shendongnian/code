    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);
    
    public static void Main()
    {
       ...
       MessageBox(new IntPtr(0), "Hello World!", "MyApp", 0);

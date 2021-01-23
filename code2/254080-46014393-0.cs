    [DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
    public static extern bool DeleteObject(IntPtr hObject);
    
    public Form1()
    {
        InitializeComponent();
        IntPtr handle = CreateRoundRectRgn(0, 0, Width, Height, 20, 20);
        if (handle == IntPtr.Zero)
            ; // error with CreateRoundRectRgn
        Region = System.Drawing.Region.FromHrgn(handle);
        DeleteObject(handle);
    }

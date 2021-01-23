    [DllImport("user32.dll")]
    static extern void ClipCursor(ref System.Drawing.Rectangle rect);
    
    [DllImport("user32.dll")]
    static extern void ClipCursor(IntPtr rect);
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        System.Drawing.Rectangle r = new System.Drawing.Rectangle(10, 10, 500, 500);
        ClipCursor(ref r);
    }
    
    private void button2_Click(object sender, RoutedEventArgs e)
    {
        ClipCursor(IntPtr.Zero);
    }

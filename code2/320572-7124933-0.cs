    //InitializeComponent
    this.tabPresentations.HandleCreated += new System.EventHandler(TabControl_HandleCreated);
    
    void TabControl_HandleCreated(object sender, System.EventArgs e)
    {
         // Send TCM_SETMINTABWIDTH
         SendMessage((sender as TabControl).Handle, 0x1300 + 49, IntPtr.Zero, (IntPtr)4);
    }
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

    private static Control GetFocusedControl()
    {
        Control focused = null;
        var handle = GetFocusedControlHandle();
    
        if (handle != IntPtr.Zero)
        {
            focused = Control.FromHandle(handle);
        }
    
        return focused;
    }
    // ...
    [DllImport("user32.dll")]
    private static extern IntPtr GetFocusedControlHandle();

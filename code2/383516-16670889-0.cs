    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
    
    public static void SetHint(TextBox textBox, string hintText)
    {
     const uint EmSetCueBanner = 0x1501;
     SendMessage(textBox.Handle, EmSetCueBanner, 0, hintText);
    }

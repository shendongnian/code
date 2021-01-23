    [DllImport("User32.dll")]
    static extern IntPtr GetDC(IntPtr hwnd);
    
    [DllImport("User32.dll")]
    static extern void ReleaseDC(IntPtr dc);
    
    private void DrawDeskTop()
    {
      IntPtr desk = GetDC(IntPtr.Zero);
      using (Graphics g = Graphics.FromHdc(desk))
      {
        g.FillRectangle(Brushes.Red, new Rectangle((SystemInformation.WorkingArea.Width / 2) - 4, (SystemInformation.WorkingArea.Height / 2) - 20, 8, 40));
        g.FillRectangle(Brushes.Red, new Rectangle((SystemInformation.WorkingArea.Width / 2) - 20, (SystemInformation.WorkingArea.Height / 2) - 4, 40, 8));
      }
      ReleaseDC(desk);
    }

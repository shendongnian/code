        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr dc);
        protected override void OnPaint(PaintEventArgs e)
        {
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopDC);
            g.DrawString("Test", new Font(FontFamily.GenericSerif, 12), Brushes.Blue, 300, 300);
            g.Dispose();
            ReleaseDC(desktopDC);
        }

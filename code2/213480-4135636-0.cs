        [Flags]
        private enum DrawingOptions
        {
            PRF_CHECKVISIBLE = 0x00000001,
            PRF_NONCLIENT = 0x00000002,
            PRF_CLIENT = 0x00000004,
            PRF_ERASEBKGND = 0x00000008,
            PRF_CHILDREN = 0x00000010,
            PRF_OWNED = 0x00000020
        }
        private const uint WM_PAINT = 0xF;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr dc, DrawingOptions opts);
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            using (Bitmap bm = new Bitmap(axChartSpace1.Width, axChartSpace1.Height))
            {
                using (Graphics g = Graphics.FromImage(bm))
                {
                    IntPtr dc = g.GetHdc();
                    try
                    {
                        SendMessage(axChartSpace1.Handle, WM_PRINT, dc,
                        DrawingOptions.PRF_CLIENT |
                        DrawingOptions.PRF_NONCLIENT |
                        DrawingOptions.PRF_CHILDREN);
                    }
                    finally
                    {
                        g.ReleaseHdc();
                    }
                    bm.Save(@"C:\1.bmp");
                }
            }
        }

    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        private static extern IntPtr GetDesktopWindow();
        public static void DrawBitmapToScreen(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetDC(hwnd);
            using (Graphics g = Graphics.FromHdc(hdc))
            {
                g.DrawImage(bmp, new Point(0, 0));
            }
            ReleaseDC(hwnd, hdc);
        }

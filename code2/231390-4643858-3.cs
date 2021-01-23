        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);
        private void ScreenShot()
        {
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            using (var screenshot = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using (var fromHwnd = Graphics.FromHwnd(new IntPtr(0)))
                using (var graphics = Graphics.FromImage(screenshot))
                {
                    IntPtr hdc_screen = fromHwnd.GetHdc();
                    IntPtr hdc_screenshot = graphics.GetHdc();
                    BitBlt(hdc_screenshot, 0, 0, width, height, hdc_screen, 0, 0, 0x00CC0020); /*SRCCOPY = 0x00CC0020*/
                    graphics.ReleaseHdc(hdc_screenshot);
                    fromHwnd.ReleaseHdc(hdc_screen);
                }
                screenshot.Save("screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

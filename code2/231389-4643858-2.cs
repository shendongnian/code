    [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr SelectPalette(
            IntPtr hdc,
            IntPtr htPalette,
            bool bForceBackground);
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern int RealizePalette(IntPtr hdc);
        private void ScreenShot()
        {
            IntPtr htPalette = Graphics.GetHalftonePalette();
            using (var screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using (var graphics = Graphics.FromImage(screenshot))
                {
                    IntPtr hdc = graphics.GetHdc();
                    SelectPalette(hdc, htPalette, true);
                    RealizePalette(hdc);
                    graphics.ReleaseHdc(hdc);
                    graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                }
                screenshot.Save("screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

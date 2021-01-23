    public class ScreenshotManager
    {
        private Image screenshot;
        
        public Image Screenshot
        {
            get
            {
                if (screenshot == null)
                    MakeScreenshot();
        
                    return screenshot;
                }
            }
        
        public MemoryStream ScreenshotToMemoryStream()
        {
            MemoryStream ms = new MemoryStream();
            Screenshot.Save(ms, ImageFormat.Jpeg);
            ms.Position = 0;
            return ms;
        }
        
        public byte[] ScreenshotToByteArray()
        {
            return ScreenshotToMemoryStream().ToArray();
        }
        
        public void MakeScreenshot()
        {
            screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
    
            var graphics = Graphics.FromImage(screenshot);
            graphics.CopyFromScreen(0, 0, Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
        }
    }

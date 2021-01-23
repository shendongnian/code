    int x = (this.Width / 2) - 400;
    int y = ((this.Height + SystemInformation.CaptionHeight) / 2) - 200;
    
    Rectangle bounds = new Rectangle(x, y, 800, 400);
                
    using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb))
    {
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            IntPtr hdc = graphics.GetHdc();
            POINT pt;
    
            SetViewportOrgEx(hdc, -x, -y, out pt);
    
            // rest as before
        }
    }

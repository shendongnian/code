    int width =
        Screen.PrimaryScreen.Bounds.Width,
        height = Screen.PrimaryScreen.Bounds.Height;
    
    Bitmap screen = default( Bitmap );
    
    try
    {
        screen = new Bitmap
        (
            width,
            height,
            Screen.PrimaryScreen.BitsPerPixel == 32 ?
                PixelFormat.Format32bppRgb :
                    PixelFormat.Format16bppRgb565
        );
    
        using (Graphics graphics = Graphics.FromImage(screen))
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
    
            graphics.CopyFromScreen
            (
                new Point() { X = 0, Y = 0 },
                new Point() { X = 0, Y = 0 },
                new Size() { Width = width, Height = height },
                CopyPixelOperation.SourceCopy
            );
    
            // Draw over the "capture" with Graphics object
        }
    }
    finally
    {
        if (screen != null)
        {
            screen.Dispose();
        }
    }

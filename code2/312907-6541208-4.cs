    public Bitmap ProportionallyResizeBitmap (Bitmap src, int maxWidth, int maxHeight)
    {
    // original dimensions
    int w = src.Width;
    int h = src.Height;
    
    // Longest and shortest dimension
    int longestDimension = (w>h)?w: h;
    int shortestDimension = (w<h)?w: h;
    
    // propotionality
    float factor = ((float)longestDimension) / shortestDimension;
    
    // default width is greater than height
    double newWidth = maxWidth;
    double newHeight = maxWidth/factor;
    
    // if height greater than width recalculate
    if ( w < h )
    {
        newWidth = maxHeight / factor;
        newHeight = maxHeight;
    }
    
    // Create new Bitmap at new dimensions
    Bitmap result = new Bitmap((int)newWidth, (int)newHeight);
    using ( Graphics g = Graphics.FromImage((System.Drawing.Image)result) )
    g.DrawImage(src, 0, 0, (int)newWidth, (int)newHeight);
    
    return result;
    }

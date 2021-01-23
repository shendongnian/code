    private void drawMap(Graphics g, ref Point location)
    {
        // Create the new bitmap and associated graphics object
        // Bitmap bmp = new Bitmap(viewSize.Width, viewSize.Height);
        // Graphics g = Graphics.FromImage(bmp);
    
        // Draw the specified section of the source bitmap to the new one
        g.DrawImage(Map, location.X, location.Y, viewSize.Width, viewSize.Height);
    
        // Clean up
        g.Dispose();
    
        // Return the bitmap
        return bmp;
    }

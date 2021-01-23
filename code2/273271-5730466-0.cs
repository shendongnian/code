    using (Bitmap bmp = new Bitmap(100, 100))
    {
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.FillRectangle(Brushes.Red, 10, 10, 50, 50);
            g.FillRectangle(Brushes.Blue, 20, 20, 50, 50);
            g.FillRectangle(Brushes.Green, 0, 0, bmp.Width, bmp.Height);
    
            g.Flush(); // !!
    
            var bmp2 = GraphicsBitmapConverter.GraphicsToBitmap(g, Rectangle.Truncate(g.VisibleClipBounds));
        }
    }

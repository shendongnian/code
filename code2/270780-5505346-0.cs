    public static Image GetImage(Visual target)
    {
        if (target == null)
        {
            return null; // No visual - no image.
        }
        var bounds = VisualTreeHelper.GetDescendantBounds(target);
    
        var bitmapHeight = 0;
        var bitmapWidth = 0;
    
        if (bounds != Rect.Empty)
        {
            bitmapHeight = (int)(Math.Floor(bounds.Height) + 1);
            bitmapWidth = (int)(Math.Floor(bounds.Width) + 1);
        }
    
        const double dpi = 96.0;
    
        var renderBitmap =
            new RenderTargetBitmap(bitmapWidth, bitmapHeight, dpi, dpi, PixelFormats.Pbgra32);
    
        var visual = new DrawingVisual();
        using (var context = visual.RenderOpen())
        {
            var brush = new VisualBrush(target);
            context.DrawRectangle(brush, null, new Rect(new Point(), bounds.Size));
        }
    
        renderBitmap.Render(visual);
    
        return new Image
        {
            Source = renderBitmap,
            Width = bitmapWidth,
            Height = bitmapHeight
        };
    }

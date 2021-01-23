    public static void DrawCenteredText(Graphics canvas, Font font, float size, Rectangle bounds, string text)
    {
        var path = new GraphicsPath();
        path.AddString(text, font.FontFamily, (int)font.Style, size, new Point(0, 0), StringFormat.GenericTypographic);
    
        // Determine physical size of the character when rendered
        var area = Rectangle.Round(path.GetBounds());
    
        // Slide it to be centered in the specified bounds
        var offset = new Point(bounds.Left + (bounds.Width / 2 - area.Width / 2) - area.Left, bounds.Top + (bounds.Height / 2 - area.Height / 2) - area.Top);
        var translate = new Matrix();
        translate.Translate(offset.X, offset.Y);
        path.Transform(translate);
    
        // Now render it however desired
        canvas.SmoothingMode = SmoothingMode.AntiAlias;
        canvas.FillPath(SystemBrushes.ControlText, path);
    }

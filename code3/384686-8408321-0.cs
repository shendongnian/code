    public RectangleF Viewport
    {
        get
        {
            if (AutoScrollMinSize.Width <= ClientRectangle.Width && AutoScrollMinSize.Height < ClientRectangle.Height)
            {
                return BitmapRectF;
            }
            else
            {
                return new RectangleF(
                    Math.Abs(AutoScrollPosition.X / _ratio),
                    Math.Abs(AutoScrollPosition.Y / _ratio),
                    Math.Min(CanvasBounds.Width / _ratio, ClientRectangle.Width / _ratio),
                    Math.Min(CanvasBounds.Height / _ratio, ClientRectangle.Height / _ratio)
                );
            }
        }
    }

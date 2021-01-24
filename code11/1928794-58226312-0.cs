    public static class ViewBoxTracking
    {
        // Source is an UIElement that will provide the mouse input
        // for calculating of the view box bounds.
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.RegisterAttached("Source", typeof(UIElement), typeof(ViewBoxTracking), new PropertyMetadata(null, SourceChanged));
        public static void SetSource(TileBrush brush, UIElement value) => brush.SetValue(SourceProperty, value);
        public static UIElement GetSource(TileBrush brush) => (UIElement)brush.GetValue(SourceProperty);
        private const int ZoomFactor = 3;
        private static void SourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs ea)
        {
            if (ea.NewValue is UIElement source && d is ImageBrush target)
            {
                // When the mouse cursor exits the source element,
                // reset the view box to the 100% zoom;
                // you can remove or change this logic.
                source.MouseLeave += (s, e) => target.Viewbox = new Rect(0, 0, 1, 1);
                // When the mouse hovers over the source object, update the view box.
                source.MouseMove += (s, e) => SourceMouseMove(target, e.GetPosition(source), source.RenderSize);
            }
        }
        private static void SourceMouseMove(ImageBrush target, Point currentPoint, Size sourceSize)
        {
            // The view box width is based on the zoom factor
            double viewBoxWidth = sourceSize.Width / ZoomFactor;
            double viewBoxHeight = sourceSize.Height / ZoomFactor;
            // Calculate the bounds for the view box - at first, in absolute coordinates.
            double x = Math.Max(0, currentPoint.X - viewBoxWidth / 2);
            double y = Math.Max(0, currentPoint.Y - viewBoxHeight / 2);
            if (x + viewBoxWidth > sourceSize.Width)
            {
                x = sourceSize.Width - viewBoxWidth;
            }
            if (y + viewBoxHeight > sourceSize.Height)
            {
                y = sourceSize.Height - viewBoxHeight;
            }
            // Now, make the coordinates relative.
            x /= sourceSize.Width;
            y /= sourceSize.Height;
            // Set the new view box to the target image brush.
            target.Viewbox = new Rect(x, y, 1d / ZoomFactor, 1d / ZoomFactor);
        }
    }

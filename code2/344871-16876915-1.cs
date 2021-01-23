    public class DrawingElement : FrameworkElement
    {
        static readonly TranslateTransform tt_cache = new TranslateTransform();
        public DrawingElement(Drawing drawing)
        {
            this.drawing = drawing;
        }
        readonly Drawing drawing;
        TranslateTransform get_transform()
        {
            if (Margin.Left == 0 && Margin.Top == 0)
                return null;
            tt_cache.X = Margin.Left;
            tt_cache.Y = Margin.Top;
            return tt_cache;
        }
        protected override Size MeasureOverride(Size _)
        {
            var sz = drawing.Bounds.Size;
            return new Size
            {
                Width = sz.Width + Margin.Left + Margin.Right,
                Height = sz.Height + Margin.Top + Margin.Bottom,
            };
        }
        protected override void OnRender(DrawingContext dc)
        {
            var tt = get_transform();
            if (tt != null)
                dc.PushTransform(tt);
            dc.DrawDrawing(drawing);
            if (tt != null)
                dc.Pop();
        }
    };

    public class HollowTextBlock : FrameworkElement
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(HollowTextBlock), new UIPropertyMetadata(string.Empty));
        public Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
        public static readonly DependencyProperty BackgroundProperty =
            TextElement.BackgroundProperty.AddOwner(typeof(HollowTextBlock), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            var extent = new RectangleGeometry(new Rect(0.0, 0.0, RenderSize.Width, RenderSize.Height));
            var face = new Typeface("Arial");
            var size = 32;
            var ft = new FormattedText(Text, Thread.CurrentThread.CurrentUICulture, FlowDirection.LeftToRight, face, size, Brushes.Black);
            var hole = ft.BuildGeometry(new Point((RenderSize.Width - ft.Width) / 2, (RenderSize.Height - ft.Height) / 2));
            var combined = new CombinedGeometry(GeometryCombineMode.Exclude, extent, hole);
            drawingContext.PushClip(combined);
            drawingContext.DrawRectangle(Background, null, new Rect(0.0, 0.0, RenderSize.Width, RenderSize.Height));
            drawingContext.Pop();
        }
    }

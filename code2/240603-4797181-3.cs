    public class StretchText : Control
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            FormattedText formattedText = new FormattedText(
                Text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface(FontFamily, FontStyle, FontWeight, FontStretches.Normal),
                FontSize,
                Foreground);
            Geometry textGeometry = formattedText.BuildGeometry(new Point(0, 0));
            this.MinWidth = textGeometry.Bounds.Width;
            this.MinHeight = textGeometry.Bounds.Height;
            TranslateTransform translateTransform = new TranslateTransform();
            translateTransform.X = -textGeometry.Bounds.Left;
            translateTransform.Y = -textGeometry.Bounds.Top;
            drawingContext.PushTransform(translateTransform);
            drawingContext.DrawGeometry(Foreground, new Pen(Foreground, 1.0), textGeometry);
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text",
            typeof(string),
            typeof(StretchText),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender));
    }

    public class StretchText : Control
    {
        private Geometry m_textGeometry;
        protected override void OnRender(DrawingContext drawingContext)
        {
            CreateTextGeometry();
            TranslateTransform translateTransform = new TranslateTransform();
            translateTransform.X = -m_textGeometry.Bounds.Left;
            translateTransform.Y = -m_textGeometry.Bounds.Top;
            drawingContext.PushTransform(translateTransform);
            drawingContext.DrawGeometry(Foreground, new Pen(Foreground, 1.0), m_textGeometry);
        }
        public void CreateTextGeometry()
        {
            FormattedText formattedText = new FormattedText(
                Text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface(FontFamily, FontStyle, FontWeight, FontStretches.Normal),
                FontSize,
                Foreground);
            m_textGeometry = formattedText.BuildGeometry(new Point(0, 0));
            this.MinWidth = m_textGeometry.Bounds.Width;
            this.MinHeight = m_textGeometry.Bounds.Height;
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

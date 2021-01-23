    public class InvertOpacityText : Image
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text",
                                        typeof(string),
                                        typeof(InvertOpacityText),
                                        new FrameworkPropertyMetadata(string.Empty,
                                                                      TargetPropertyChanged));
        public static readonly DependencyProperty EmSizeProperty =
            DependencyProperty.Register("EmSize",
                                        typeof(double),
                                        typeof(InvertOpacityText),
                                        new FrameworkPropertyMetadata(70.0,
                                                                      TargetPropertyChanged));
        public static readonly DependencyProperty FontFamilyProperty =
            DependencyProperty.Register("FontFamily",
                                        typeof(FontFamily),
                                        typeof(InvertOpacityText),
                                        new FrameworkPropertyMetadata(new FontFamily(),
                                                                      TargetPropertyChanged));
        private static void TargetPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            InvertOpacityText invertOpacityText = (InvertOpacityText)source;
            invertOpacityText.OnTextChanged();
        }
        public string Text
        {
            get { return (string)base.GetValue(TextProperty); }
            set { base.SetValue(TextProperty, value); }
        }
        public double EmSize
        {
            get { return (double)base.GetValue(EmSizeProperty); }
            set { base.SetValue(EmSizeProperty, value); }
        }
        public FontFamily FontFamily
        {
            get { return (FontFamily)base.GetValue(FontFamilyProperty); }
            set { base.SetValue(FontFamilyProperty, value); }
        }
        private void OnTextChanged()
        {
            if (Source == null)
            {
                Source = CreateBitmapSource();
            }
            FormattedText tx = new FormattedText(Text,
                                                 Thread.CurrentThread.CurrentUICulture,
                                                 FlowDirection.LeftToRight,
                                                 new Typeface(FontFamily,
                                                              FontStyles.Normal,
                                                              FontWeights.Bold,
                                                              FontStretches.Normal),
                                                 EmSize,
                                                 Brushes.Black);
            Geometry textGeom = tx.BuildGeometry(new Point(0, 0));
            Rect boundingRect = new Rect(new Point(-100000, -100000), new Point(100000, 100000));
            RectangleGeometry boundingGeom = new RectangleGeometry(boundingRect);
            GeometryGroup group = new GeometryGroup();
            group.Children.Add(boundingGeom);
            group.Children.Add(textGeom);
            Clip = group;
        }
        private BitmapSource CreateBitmapSource()
        {
            int width = 128;
            int height = width;
            int stride = width / 8;
            byte[] pixels = new byte[height * stride];
            List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>();
            colors.Add(System.Windows.Media.Colors.Red);
            colors.Add(System.Windows.Media.Colors.Blue);
            colors.Add(System.Windows.Media.Colors.Green);
            BitmapPalette myPalette = new BitmapPalette(colors);
            return BitmapSource.Create(width,
                                       height,
                                       96,
                                       96,
                                       PixelFormats.Indexed1,
                                       myPalette,
                                       pixels,
                                       stride);
        }
    }

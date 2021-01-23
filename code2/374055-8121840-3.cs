    public class ResizeCanvasBehaviour : Behavior<Image>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SizeChanged += AssociatedObject_SizeChanged;
            AssociatedObject.ImageOpened += AssociatedObject_ImageOpened;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SizeChanged -= AssociatedObject_SizeChanged;
            AssociatedObject.ImageOpened -= AssociatedObject_ImageOpened;
        }
        private void AssociatedObject_ImageOpened(object sender, RoutedEventArgs e)
        {
            BitmapSource bitmapSource = AssociatedObject.Source as BitmapSource;
            if (bitmapSource == null)
            {
                return;
            }
            AssociatedObject.Width = bitmapSource.PixelWidth;
            AssociatedObject.Height = bitmapSource.PixelHeight;
            Resize();
        }
        private void AssociatedObject_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Resize();
        }
        public Canvas Canvas
        {
            get { return GetValue(CanvasProperty) as Canvas; }
            set { SetValue(CanvasProperty, value); }
        }
        public static readonly DependencyProperty CanvasProperty = DependencyProperty.Register(
            "Canvas",
            typeof(Canvas),
            typeof(ResizeCanvasBehaviour),
            new PropertyMetadata(null, CanvasPropertyChanged));
        private static void CanvasPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ResizeCanvasBehaviour)d).OnCanvasPropertyChanged();
        }
        private void OnCanvasPropertyChanged()
        {
            if (Canvas != null)
            {
                Resize();
            }
        }
        private void Resize()
        {
            if ((AssociatedObject != null) && (Canvas != null))
            {
                Canvas.Width = AssociatedObject.ActualWidth;
                Canvas.Height = AssociatedObject.ActualHeight;
            }
        }
    }

    public class ResizeCanvasBehaviour : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SizeChanged += Canvas_SizeChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SizeChanged -= Canvas_SizeChanged;
        }
        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
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

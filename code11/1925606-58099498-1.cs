    public class ViewModel
    {
        public RectangleGeometry TransformedRectangle { get; } = new RectangleGeometry();
        public ViewModel()
        {
            var transform = new TransformGroup();
            transform.Children.Add(new ScaleTransform(2, 1));
            transform.Children.Add(new SkewTransform(30, 0));
            transform.Children.Add(new RotateTransform(45, 250, 150));
            TransformedRectangle.Rect = new Rect(100, 100, 100, 100);
            TransformedRectangle.Transform = transform;
        }
    }

    public class Tabby : HeaderedContentControl
    {
        static Tabby()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Tabby), new FrameworkPropertyMetadata(typeof(Tabby)));
        }
        public double DogEar
        {
            get { return (double)GetValue(DogEarProperty); }
            set { SetValue(DogEarProperty, value); }
        }
        public static readonly DependencyProperty DogEarProperty =
            DependencyProperty.Register("DogEar",
            typeof(double), 
            typeof(Tabby),
            new UIPropertyMetadata(8.0, DogEarPropertyChanged));
        private static void DogEarPropertyChanged(
            DependencyObject obj, 
            DependencyPropertyChangedEventArgs e)
        {
            ((Tabby)obj).InvalidateVisual();
        }
        public Tabby()
        {
            this.SizeChanged += new SizeChangedEventHandler(Tabby_SizeChanged);
        }
        void Tabby_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var clip = new PathGeometry();
            clip.Figures = new PathFigureCollection();
            clip.Figures.Add(
                new PathFigure(
                    new Point(0, 0),
                    new[] {
                        new LineSegment(new Point(this.ActualWidth - DogEar, 0), true),
                        new LineSegment(new Point(this.ActualWidth, DogEar), true), 
                        new LineSegment(new Point(this.ActualWidth, this.ActualHeight), true),
                        new LineSegment(new Point(0, this.ActualHeight), true) },
                    true)
            );
            this.Clip = clip;
        }
    }

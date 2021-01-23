    namespace Zoom
    {
        public partial class Window1
        {   
            public double ZoomLevel { get; set; }
            public double SlideLevel { get; set; }
            public Window1()
            {
                InitializeComponent();
                ZoomLevel = 1.0;
                SlideLevel = 1.0;
                image.MouseWheel += image_MouseWheel;
            
            }
            private void image_MouseWheel(object sender, MouseWheelEventArgs e)
            {
                double zoom = e.Delta > 0 ? .1 : -.1;
                slider.Value = (SlideLevel + zoom);
            }
            private void ZoomImage(double zoom)
            {
                Storyboard storyboardh = new Storyboard();
                Storyboard storyboardv = new Storyboard();
                ScaleTransform scale = new ScaleTransform(ZoomLevel, ZoomLevel);
                image.RenderTransformOrigin = new Point(0.5, 0.5);
                image.RenderTransform = scale;
                double startNum = ZoomLevel;
                double endNum = (ZoomLevel += zoom);
                if (endNum > 1.0)
                {
                    endNum = 1.0;
                    ZoomLevel = 1.0;
                }
                DoubleAnimation growAnimation = new DoubleAnimation();
                growAnimation.Duration = TimeSpan.FromMilliseconds(300);
                growAnimation.From = startNum;
                growAnimation.To = endNum;
                storyboardh.Children.Add(growAnimation);
                storyboardv.Children.Add(growAnimation);
                Storyboard.SetTargetProperty(growAnimation, new PropertyPath("RenderTransform.ScaleX"));
                Storyboard.SetTarget(growAnimation, image);
                storyboardh.Begin();
                Storyboard.SetTargetProperty(growAnimation, new PropertyPath("RenderTransform.ScaleY"));
                Storyboard.SetTarget(growAnimation, image);
                storyboardv.Begin();
            }
            private void slider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
            {
                double zoomChange = (SlideLevel - slider.Value) * -1;
                SlideLevel = SlideLevel + zoomChange;
            
                ZoomImage(zoomChange);
            }
        }
    }

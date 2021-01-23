    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    namespace PhoneApp4
    {
        public partial class MainPage : PhoneApplicationPage
        {
            // Constructor
            public MainPage()
            {
                InitializeComponent();
                this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            }
            void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                GeneralTransform generalTransform = border1.TransformToVisual(LayoutRoot);
                Point point = generalTransform.Transform(new Point(1, 1));
                var controls = FindElementsAtCoordinates(point);
            }
            private UIElement[] FindElementsAtCoordinates(Point point)
            {
                if ((this.Orientation & PageOrientation.Portrait) == 0)
                {
                    if (this.Orientation == PageOrientation.LandscapeLeft)
                        point = new Point(
                            this.ActualHeight - point.Y,
                            point.X + (SystemTray.IsVisible ? 72 : 0));
                    else
                        point = new Point(
                            point.Y,
                            this.ActualWidth - point.X + (SystemTray.IsVisible ? 72 : 0));
                }
                return VisualTreeHelper.FindElementsInHostCoordinates(
                    new Point(point.X, point.Y + (SystemTray.IsVisible ? 72 : 0)),
                    page).ToArray();
            }
        }
    }

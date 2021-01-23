    using System.Windows;
    using System.Windows.Media;
    using System.Globalization;
    namespace TextDrawing
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                FormattedText atoz = new FormattedText("ABC...XYZ",
                    CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                    new Typeface("Arial"), 50.0, Brushes.Black);
                Geometry geo = atoz.BuildGeometry(new Point(0, 0));
                geoDrawing.Geometry = geo;
                geoDrawing.Pen = new Pen(Brushes.Black, 1.0);
                geoDrawing.Brush = Brushes.Yellow;
            }
        }
    }

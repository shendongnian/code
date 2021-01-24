    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
    
            public void DrawTextInRectangle(object sender, RoutedEventArgs e)
            {
                StylusPointCollection pts = new StylusPointCollection();
    
                pts.Add(new StylusPoint(100, 100));
    
                pts.Add(new StylusPoint(100, 300));
    
                pts.Add(new StylusPoint(300, 300));
    
                pts.Add(new StylusPoint(300, 100));
    
                pts.Add(new StylusPoint(100, 100));
    
                CustomStroke st = new CustomStroke(pts);
    
                st.DrawingAttributes.Color = Colors.Red;
                inkCanvas1.Strokes.Add(st);
    
    
    
            }
    
    
    
    
        }
    
    }
    
        // A class for rendering custom strokes
        class CustomStroke : Stroke
        {
            Brush brush;
            Pen pen;
    
            public CustomStroke(StylusPointCollection stylusPoints)
                : base(stylusPoints)
            {
                // Create the Brush and Pen used for drawing.
                brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 20d);
                pen = new Pen(brush, 2d);
            }
    
            protected override void DrawCore(DrawingContext drawingContext,
                                             DrawingAttributes drawingAttributes)
            {
                // Allocate memory to store the previous point to draw from.
                Point prevPoint = new Point(double.NegativeInfinity,
                                            double.NegativeInfinity);
    
                // Draw linear gradient ellipses between 
                // all the StylusPoints in the Stroke.
                for (int i = 0; i < this.StylusPoints.Count; i++)
                {
                    Point pt = (Point)this.StylusPoints[i];
                    Vector v = Point.Subtract(prevPoint, pt);
    
                    // Only draw if we are at least 4 units away 
                    // from the end of the last ellipse. Otherwise, 
                    // we're just redrawing and wasting cycles.
                    if (v.Length > 4)
                    {
                        // Set the thickness of the stroke 
                        // based on how hard the user pressed.
                        double radius = this.StylusPoints[i].PressureFactor * 10d;
                        drawingContext.DrawEllipse(brush, pen, pt, radius, radius);
    
                        prevPoint = pt;
                    }
                }
                Typeface tf = new Typeface("Arial");
                FormattedText ft = new FormattedText("test test", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, tf, 15, Brushes.Red);
                drawingContext.DrawText(ft, new Point(1.5 * prevPoint.X, 1.5 * prevPoint.Y));
    
    
    
            }
        }

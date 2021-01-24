    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    namespace WpfApp9
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;      
            }
            private double xval = 50;
            public double xcoord
            {
                get=> xval; 
                set
                {
                    xval = value;
                    CreateARectangle();
                }
            }
            private double yval = 50;
            public double ycoord
            {
                get => yval;
                set
                {
                    yval = value;
                    CreateARectangle();
                }
            }
            Rectangle rect = null;
            public void CreateARectangle()
            {
                if (rect == null)
                {
                    // Creates a Rectangle  
                    rect = new Rectangle();
                    rect.Height = ycoord;
                    rect.Width = xcoord;
                    // Create a Brush  
                    SolidColorBrush colorbrush = new SolidColorBrush();
                    colorbrush.Color = Colors.Red;
                    colorbrush.Opacity = .3;
                    SolidColorBrush blackBrush = new SolidColorBrush();
                    blackBrush.Color = Colors.Black;
                    // Set Rectangle's width and color  
                    rect.StrokeThickness = 1;
                    rect.Stroke = blackBrush;
                    // Fill rectangle with color  
                    rect.Fill = colorbrush;
                    // Add Rectangle to the Grid.  
                    can.Children.Add(rect);
                } 
                else
                {
                    rect.Height = ycoord;
                    rect.Width = xcoord;
                }
            }
        }
    }

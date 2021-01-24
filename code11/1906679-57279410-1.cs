    using HelixToolkit.Wpf;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;
    
    namespace WpfApp10
    {
        /// <summary>
        /// Lógica de interacción para MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            SphereVisual3D ball;
            double x = 5;
            double y = 0;
            double z = 0;
            double acceleration = 0.5;
    
            public MainWindow()
            {
                InitializeComponent();
    
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                ball = new SphereVisual3D
                {
                    Center = new Point3D(1.5, 1, 1),
                    Radius = 0.5,
                    Material = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(255, 197, 147))),
                    Transform = new TranslateTransform3D(x, y, z),
                    Visible = true
                };
                viewPort.Children.Add(ball);
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (y < -5)
                {
                    y = 2;
                }
                if (x < -5)
                {
                    x = 2;
                }
                if (z > 5)
                {
                    z = -2;
                }
    
                y -= acceleration;
                x -= 0.5;
                z += 0.5;
                ball.Transform = new TranslateTransform3D(x, y, z);
            }
        }
    }

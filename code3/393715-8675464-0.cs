    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using System.Windows.Controls.DataVisualization.Charting;
    using System.Windows.Media.Imaging;
    
    namespace SilverlightApplication1
    {
        public partial class MainPage : UserControl
        {
            Chart chart_;
    
            public MainPage()
            {
                InitializeComponent();
    
                var data = new List<Point>(100);
                for (int i = 0; i < 100; i++)
                {
                    data.Add(new Point(i, Math.Sin(i * Math.PI / 50)));
                }
    
                chart_ = new Chart()
                {
                    Name = "Chart",
                    Width = 512,
                    Height = 512
                };
                LineSeries line = new LineSeries()
                {
                    Name = "Line",
                    Title = "test",
                    IndependentValuePath = "X",
                    DependentValuePath = "Y",
                    ItemsSource = data
                };
                chart_.Series.Add(line);
                LayoutRoot.Children.Add(chart_); // I tried to add chart_ to visual tree, It doesn't help  
            }
    
            private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
            {
                //creates bitmap 
                WriteableBitmap bitmap;
                ScaleTransform t = new ScaleTransform() { ScaleX = 1.0, ScaleY = 1.0 };
                //bitmap = new WriteableBitmap(chart_, t); Tried it also with this way 
                bitmap = new WriteableBitmap(512, 512);
                bitmap.Render(chart_, t);
                //texture = new Texture2D(GraphicsDeviceManager.Current.GraphicsDevice, bitmap.PixelWidth, bitmap.PixelHeight, false, SurfaceFormat.Color);
                //bitmap.CopyTo(texture); 
                image1.Source = bitmap;
            }
        }
    }
    

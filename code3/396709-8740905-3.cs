    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace GeometryParts
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                Navigator navigator = new Navigator(0, 0);
    
                navigator.NavigateTo(30, 30);
                navigator.NavigateTo(60, 0);
    
                Tuple<string, Point[]> stroke = navigator.Stroke();
                this.g.Data = Geometry.Parse(stroke.Item1);
    
                MessageBox.Show(stroke.Item2.Length.ToString());
            }
        }
    
    
        public class Navigator
        {
            private List<Point> points = new List<Point>();
    
            public Navigator(double x, double y)
            {
                this.points.Add(new Point(x, y));
            }
    
            public void NavigateTo(double x, double y)
            {
                this.points.Add(new Point(x, y));
            }
    
            public Tuple<string, Point[]> Stroke()
            {
                string path = this.points.Select(t => t.ToString()).Aggregate((f, s) => "L" + f + " L" + s);
                path = "M" + path.Substring(2, path.Length - 2);
    
                Tuple<string, Point[]> stroke = new Tuple<string, Point[]>(path, this.points.ToArray());
                points.Clear();
                
                return stroke;
            }
        }
    }

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
    
    namespace DrawInCanvas
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
                // just a sample
                Dictionary<int, string> barDefinitions = new Dictionary<int, string>(3)
                {
                    { 1, "100$red" },
                    { 2, "220$yellow" },
                    { 3, "40$blue" }
                };
    
                this.g.ItemsSource =
                    Enumerable.Range(1, 3).Select(t => 
                        new Tuple<int, string>(t, barDefinitions[t]));
            }
        }
    
        public class CanvasDrawing : DependencyObject
        {
            public static readonly DependencyProperty DrawingProperty =
                DependencyProperty.RegisterAttached("Drawing",
                    typeof(string),
                    typeof(CanvasDrawing),
                    new PropertyMetadata(new PropertyChangedCallback((o, e) => 
                    {
                        CanvasDrawing.Draw((Canvas)o, (string)e.NewValue);
                    })));
    
            public static void SetDrawing(Canvas canvas, string drawing)
            {
                canvas.SetValue(CanvasDrawing.DrawingProperty, drawing);
            }
    
            public static string GetDrawing(Canvas canvas)
            {
                return (string)canvas.GetValue(CanvasDrawing.DrawingProperty);
            }
    
            private static void Draw(Canvas canvas, string drawing)
            {
                string[] parts = drawing.Split("$".ToCharArray());
    
                canvas.Width = double.Parse(parts[0]);
                canvas.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(parts[1]));
            }
        }
    }

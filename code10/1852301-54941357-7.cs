    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace YOurNamsepace
    {
        /// <summary>
        /// Interaction logic for myPolyLine.xaml
        /// </summary>
        public partial class myPolyLine : UserControl
        {
            public myPolyLine()
            {
                InitializeComponent();
                this.DataContext = this;
    
                this.Loaded += makeBoxes;
            }
    
            private void makeBoxes(object sender, RoutedEventArgs e)
            {
                HiddenCanvas.Children.RemoveRange(0, HiddenCanvas.Children.Count - 1);
                foreach (var point in Points)
                {
                    TextBlock tb = new TextBlock();
                    tb.Text = $" {point.X.ToString()} , {point.Y.ToString()}";
                    Border brd = new Border();
                    brd.SetValue(Canvas.LeftProperty, point.X);
                    brd.SetValue(Canvas.TopProperty, point.Y);
                    brd.BorderThickness = new Thickness(1);
                    brd.BorderBrush = new SolidColorBrush(Colors.Black);
                    brd.Child = tb;
                    HiddenCanvas.Children.Add(brd);
                }
            }
    
            public PointCollection Points
            {
                get
                {
                    return (PointCollection)this.GetValue(PointsProperty);
                }
                set
                {
                    this.SetValue(PointsProperty, value);
                }
            }
    
            // Using a DependencyProperty as the backing store for Points.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty PointsProperty =
                DependencyProperty.Register(nameof(Points), typeof(PointCollection), typeof(myPolyLine), new PropertyMetadata(default(PointCollection)));
    
    
            public Brush Stroke
            {
                get { return (Brush)this.GetValue(StrokeProperty); }
                set { this.SetValue(StrokeProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Stroke.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty StrokeProperty =
                DependencyProperty.Register(nameof(Stroke), typeof(Brush), typeof(myPolyLine), new PropertyMetadata(default(Brush)));
    
    
    
            public Thickness StrokeThickness
            {
                get { return (Thickness)this.GetValue(StrokeThicknessProperty); }
                set { this.SetValue(StrokeThicknessProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty StrokeThicknessProperty =
                DependencyProperty.Register(nameof(StrokeThickness), typeof(Thickness), typeof(myPolyLine), new PropertyMetadata(default(Thickness)));
    
    
    
    
        }
    }

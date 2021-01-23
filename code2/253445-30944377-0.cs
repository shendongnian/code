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
    
    namespace Animazioni
    {
        public partial class MainPage : UserControl
        {
            public Ellipse el = new Ellipse();
            public MainPage()
            {
                InitializeComponent();
                el.Opacity = 0.5;
                el.Height = 100;
                el.Width = 100;
                
            }
    
            private void UserControl_Loaded(object sender, RoutedEventArgs e)
            {
                RadialGradientBrush _rgb = new RadialGradientBrush();
                GradientStop gs1 = new GradientStop();
                GradientStop gs2 = new GradientStop();
                GradientStop gs3 = new GradientStop();
    
                gs1.Offset = 0;
                gs2.Offset = 0.7;
                gs3.Offset = 1;
    
                gs1.Color = Colors.Yellow;
                gs2.Color = Colors.Orange;
                gs3.Color = Colors.Red;
    
               //
    
                _rgb.GradientStops.Add(gs1);
                _rgb.GradientStops.Add(gs2);
                _rgb.GradientStops.Add(gs3);
                el.Fill = _rgb;
    
                myCanvas.Children.Add(el);
    
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Microsoft.Phone.Controls;
    
    namespace WindowsPhoneApplication1
    {
        public partial class MainPage : PhoneApplicationPage
        {
            private readonly Random _rnd = new Random();
            private List<Rectangle> _listRect;
            private Rectangle _selectedRect;
            private int _selectedRectPrevZIndex;
            public MainPage()
            {
                InitializeComponent();
                LayoutRoot.MouseMove += Rectangle_MouseMove;
                CreateAndAddRectangles();
                AddRectangles();
            }
            private void CreateAndAddRectangles()
            {
                _listRect = new List<Rectangle>(10);
                for (var i = 0; i < 10; i++)
                {
                    var rec = new Rectangle {Height = 50, Width = 50};
                    rec.SetValue(Canvas.LeftProperty, i * 30d);
                    rec.SetValue(Canvas.TopProperty, i * 30d);
                    rec.Fill = new SolidColorBrush(
                        Color.FromArgb(255,
                                       Convert.ToByte(_rnd.NextDouble() * 255),
                                       Convert.ToByte(_rnd.NextDouble() * 255),
                                       Convert.ToByte(_rnd.NextDouble() * 255)));
                    rec.MouseLeftButtonDown += Rectangle_MouseLeftButtonDown;
                    rec.MouseLeftButtonUp += Rectangle_MouseLeftButtonUp;
                    rec.MouseMove += Rectangle_MouseMove;
                    _listRect.Add(rec);
                }
            }
            private void AddRectangles()
            {
                foreach (var rec in _listRect)
                    LayoutRoot.Children.Add(rec);
            }
            private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                var rec = sender as Rectangle;
                if (rec == null)
                    return;
    
                _selectedRectPrevZIndex = (int)rec.GetValue(Canvas.ZIndexProperty);
                System.Diagnostics.Debug.WriteLine(_selectedRectPrevZIndex);
                rec.SetValue(Canvas.ZIndexProperty, 100);
                _selectedRect = rec;
            }
            private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                var rec = sender as Rectangle;
                if (rec == null || _selectedRect == null)
                    return;
    
                rec.SetValue(Canvas.ZIndexProperty, _selectedRectPrevZIndex);
                _selectedRect = null;
            }
            void Rectangle_MouseMove(object sender, MouseEventArgs e)
            {
                if (_selectedRect == null)
                    return;
    
                var pos = e.GetPosition(LayoutRoot);
                _selectedRect.SetValue(Canvas.LeftProperty, pos.X);
                _selectedRect.SetValue(Canvas.TopProperty, pos.Y);
            }
        }
    }

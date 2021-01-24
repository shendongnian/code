    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using Windows.UI;
    using Windows.UI.Xaml.Controls;
    namespace Test_One_Bar_UWP
    {
        public sealed partial class MainPage : Page
        {
            private List<double> _values = new List<double>();
            private List<Vector2> _points = new List<Vector2>();
            private Random _random = new Random();
            private float _barWidth = 30.0f;
            public MainPage()
            {
                this.InitializeComponent();
            }
            private void canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
            {
                lock (_points)
                {
                    double height = sender.Size.Height;
                    foreach (var point in _points)
                    {
                        args.DrawingSession.DrawLine(
                            point.X * _barWidth,
                            Convert.ToSingle(height),
                            point.X * _barWidth,
                            Convert.ToSingle(height) - point.Y,
                            Colors.Green, 1);
                    }
                }
            }
            private void canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args)
            {
                _values.Add(_random.NextDouble());
                double width = sender.Size.Width;
                var lastPoints = _values.TakeLast(Convert.ToInt32(width / _barWidth));
                lock (_points)
                {
                    _points.Clear();
                    for (var i = 0; i < lastPoints.Count(); i++)
                    {
                        _points.Add(new Vector2(i, Convert.ToSingle(sender.Size.Height * lastPoints.ElementAt(i))));
                    }
                }
            }
        }
    }

        public class EllipseVM : ObservableObject
        {
            private Color _Color;
            public Color Color
            {
              get => _Color;
              set => Set(ref _Color, value);
            }
            private double _X;
            public double X
            {
              get => _X;
              set => Set(ref _X, value);
            }
            private double _Y;
            public double Y
            {
              get => _Y;
              set => Set(ref _Y, value);
            }
        }

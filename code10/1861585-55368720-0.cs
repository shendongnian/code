        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(double), typeof(MainPage), new PropertyMetadata(default(double), (s
                , e) =>
            {
                ((MainPage) s)._lastValue = (double) e.OldValue;
            }));
        public double Value
        {
            get => (double) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        private double _lastValue;

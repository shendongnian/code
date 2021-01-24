        private readonly BindableProperty CustomXProperty = BindableProperty.Create(nameof(CustomX), typeof(double), typeof(MyCustomControl), defaultValue: 0.0);
        public double CustomX
        {
            get
            {
                return (double)GetValue(CustomXProperty);
            }
            set
            {
                SetValue(CustomXProperty, value);
            }
        }

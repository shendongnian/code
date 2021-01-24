        public static readonly DependencyProperty ErrorBorderHeightProperty
          = DependencyProperty.Register(
          "ErrorBorderHeight", typeof(double), typeof(MyUserControl),
          new FrameworkPropertyMetadata((double)20, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
              | FrameworkPropertyMetadataOptions.AffectsRender));
        [TypeConverter(typeof(LengthConverter))]
        public double ErrorBorderHeight
        {
            get { return (double)GetValue(ErrorBorderHeightProperty); }
            set { SetValue(ErrorBorderHeightProperty, value); }
        }

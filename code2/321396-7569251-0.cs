        public double MinMenuHeight
        {
          get { return (double)GetValue(MinMenuHeightProperty); }
          set { SetValue(MinMenuHeightProperty, value); }
        }
        public static readonly DependencyProperty MinMenuHeightProperty =
            DependencyProperty.Register("MinMenuHeight", typeof(double), typeof(RibbonApplicationMenu), new UIPropertyMetadata(0.0));
 

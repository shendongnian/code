        #region public double Percent
        public double Percent
        {
            get { return (double)GetValue(PercentProperty); }
            set { SetValue(PercentProperty, value); }
        }
        public static readonly DependencyProperty PercentProperty =
            DependencyProperty.Register(
                "Percent",
                typeof(double),
                typeof(ShowCase1),
                new PropertyMetadata(50.0, OnPercentPropertyChanged));
        private static void OnPercentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ShowCase1 source = d as ShowCase1;
            double percent = (double)e.NewValue;
            source.LayoutRoot.ColumnDefinitions[0].Width = new GridLength(percent, GridUnitType.Star);
            source.LayoutRoot.ColumnDefinitions[1].Width = new GridLength(100 - percent, GridUnitType.Star);            
        }
       #endregion public double Percent

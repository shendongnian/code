        /// <summary>
        /// Gets or sets ScrolledPosition
        /// </summary>
        public double ScrolledPosition
        {
            get { return (double)GetValue(ScrolledPositionProperty); }
            set
            {
                SetValue(ScrolledPositionProperty, value);
            }
        }
        /// <summary>
        /// Identifies the <see cref="ScrolledPosition"/> bindable property.
        /// </summary>
        public static readonly BindableProperty ScrolledPositionProperty = BindableProperty.Create("ScrolledPosition", typeof(double), typeof(CustomView), 0d, BindingMode.TwoWay, null, OnScaleFactorsChange);
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public double Position
        {
            get { return (double)GetValue(PositionProperty); }
            set
            {
                SetValue(PositionProperty, value);
            }
        }
        /// <summary>
        /// Identifies the <see cref="Position"/> bindable property.
        /// </summary>
        public static readonly BindableProperty PositionProperty = BindableProperty.Create("Position", typeof(double), typeof(CustomView), 0d, BindingMode.TwoWay, null, OnScaleFactorsChange);
        /// <summary>
        /// Gets or sets ScrollViewWidth
        /// </summary>
        public double ScrollViewWidth
        {
            get { return (double)GetValue(ScrollViewWidthProperty); }
            set
            {
                SetValue(ScrollViewWidthProperty, value);
            }
        }
        /// <summary>
        /// Identifies the <see cref="ScrollViewWidth"/> bindable property.
        /// </summary>
        public static readonly BindableProperty ScrollViewWidthProperty = BindableProperty.Create("ScrollViewWidth", typeof(double), typeof(CustomView), 0d, BindingMode.TwoWay, null, OnScaleFactorsChange);

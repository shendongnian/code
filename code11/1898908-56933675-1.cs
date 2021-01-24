        public static readonly DependencyProperty ImageSizeProperty
          = DependencyProperty.Register(
            "ImageSize",
            typeof(double),
            typeof(WindowsProfilePicker),
            new FrameworkPropertyMetadata((double)126.0, 
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
                | FrameworkPropertyMetadataOptions.AffectsRender
                | FrameworkPropertyMetadataOptions.AffectsMeasure)
        );
        [TypeConverter(typeof(LengthConverter))]
        public double ImageSize
        {
            get => (double)GetValue(ImageSizeProperty);
            set => SetValue(ImageSizeProperty, value);
        }

        public static readonly DependencyProperty ImageSizeProperty
          = DependencyProperty.Register(
            "ImageSize",
            typeof(double),
            typeof(WindowsProfilePicker),
            new FrameworkPropertyMetadata((double)126.0, 
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
                | FrameworkPropertyMetadataOptions.AffectsRender
                | FrameworkPropertyMetadataOptions.AffectsMeasure)
        {
             BindsTwoWayByDefault = true,
             DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
         });

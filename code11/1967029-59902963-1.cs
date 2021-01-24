    public static readonly DependencyProperty DataContextProperty =
        DependencyProperty.Register(
            "DataContext",
            typeof(object),
            _typeofThis,
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.Inherits,
                new PropertyChangedCallback(OnDataContextChanged)));

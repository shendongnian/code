    public static readonly DependencyProperty MyDependencyProperty =
        DependencyProperty.Register("MyDependency",
                                    typeof(propertyType),
                                    typeof(ownerType),
                                    new FrameworkPropertyMetadata {
                                        BindsTwoWayByDefault = true,
                                        PropertyChangedCallback = OnPropertyChanged,
                                        ... etc ...
                                    });

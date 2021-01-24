    public static readonly DependencyProperty EventsViewProperty = DependencyProperty.Register(
                nameof(EventsView), typeof(ICollectionView), typeof(EventsControl), new PropertyMetadata(default(ICollectionView)));
    
    public ICollectionView EventsView
    {
        get => (ICollectionView) GetValue(EventsViewProperty);
        set => SetValue(EventsViewProperty, value);
    }

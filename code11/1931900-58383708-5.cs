    public ObservableCollection<TextStyle> Items
    {
        get { return (ObservableCollection<TextStyle>)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }
    
    // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register("Items", typeof(ObservableCollection<TextStyle>), typeof(HighlightBehavior),
              new PropertyMetaData(ItemsChanged));
    
    private static void ItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var col = (ObservableCollection<TextStyle>)e.NewValue;
        if (col != null) { col.CollectionChanged += OnCollectionChanged; ; }
        col = (ObservableCollection<TextStyle>)e.OldValue;
        if (col != null) { col.CollectionChanged -= OnCollectionChanged; }
    }
    public HighlightBehavior()
    {
        SetValue(ItemsProperty, new ObservableCollection<TextStyle>());
    }

    public ObservableCollection<TextStyle> Items
    {
        get { return (ObservableCollection<TextStyle>)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }
    
    // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register("Items", typeof(ObservableCollection<TextStyle>), typeof(CompletionListBehavior),
              new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(null)));
    public HighlightBehavior()
    {
        SetValue(ItemsProperty, new ObservableCollection<TextStyle>());
        Items.CollectionChanged += OnCollectionChanged;
    }
    
    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // The code when the collection is changed.
    }

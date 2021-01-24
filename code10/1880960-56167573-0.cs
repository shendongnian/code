    ...
    public static readonly DependencyProperty FilteredSymbolsProperty = DependencyProperty.Register(nameof(FilteredSymbols), typeof(CollectionViewSource), typeof(SymbolSummaryControl));
    public CollectionViewSource FilteredSymbols
    {
        set { SetValue(FilteredSymbolsProperty, value); }
        get { return (CollectionViewSource)GetValue(FilteredSymbolsProperty); }
     }
    public ctor()
    {
        InitializeComponent();
        FilteredSymbols = (CollectionViewSource)this.Resources["filteredSymbols"];
        Debug.Assert(FilteredSymbols != null);
    }
    ...

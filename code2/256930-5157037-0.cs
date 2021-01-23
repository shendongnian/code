    public DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
                    "ItemsSource",
                    typeof(IList),
                    typeof(CustomGridControl),
                    new FrameworkPropertyMetadata(null, OnItemsSourceChanged));
    private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        e.NewValue;
    }

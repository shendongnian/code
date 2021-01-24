    public IEnumerable<Person> ItemsSource
    {
        get { return (IEnumerable<Person>)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable<Person>), typeof(UCListView), new PropertyMetadata(null));

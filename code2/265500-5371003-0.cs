    public ObservableCollection<ObjWithDesc> ItemsSource
    {
        get 
        {
            return (ObservableCollection<ObjWithDesc>)GetValue(ItemsSourceProperty); 
        }
        set
        {
            SetValue(ItemsSourceProperty, value);
        }
    }
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register(
            "ItemsSource",
            typeof(ObservableCollection<ObjWithDesc>),
            typeof(HorizontalListBox),
            new PropertyMetadata(OnItemsSourcePropertyChanged)
        );
    static void OnItemsSourcePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        ((HorizontalListBox) obj).OnItemsSourcePropertyChanged(e);
    }
    private void OnItemsSourcePropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        ObservableCollection<ObjWithDesc> objWithDescList = (ObservableCollection<ObjWithDesc>)e.NewValue;
        MainListBox.ItemsSource = objWithDescList;
    }

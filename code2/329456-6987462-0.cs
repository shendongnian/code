    public LiteTable Data
    {
        get { return (LiteTable)GetValue(DataProperty); }
        set 
        {
            object oldvalue = Data;
            SetValue(DataProperty, value);
            OnPropertyChanged(new DependencyPropertyChangedEventArgs(DataProperty, oldvalue, value));
        }
    }
    // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register("Data", typeof(LiteTable), typeof(LiteGrid), new UIPropertyMetadata(null));

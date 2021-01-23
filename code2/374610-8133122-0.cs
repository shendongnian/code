    public static DependencyProperty CurrentViewProperty = 
        DependencyProperty.Register("CurrentView", typeof(ViewStyles), typeof(ComboView),
        new FrameworkPropertyMetadata(CurrentViewPropertyChanged));
    private static void CurrentViewPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MyControl mc = (MyControl)d;
        mc.UpdateView();
    }

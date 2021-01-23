    public static readonly DependencyProperty FilterColorProperty =
        DependencyProperty.Register("FilterColor", typeof(Color),
        typeof(MyUserControl),
        new PropertyMetadata(Colors.White, FilterColorChanged));
    public static void FilterColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        if (!(obj is MyUserControl))
            return;
        MyUserControl ctrl = (MyUserControl)obj;
        var brush = ctrl.GetBrushProperty();
        if (brush.Color != (Color)e.NewValue)
            brush.Color = (Color)e.NewValue;
    }

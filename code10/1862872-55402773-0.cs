    public static readonly DependencyProperty TrueStateImageProperty =
        DependencyProperty.Register("CheckedImage", typeof(ImageSource), typeof(ImageToggleButton),
            new PropertyMetadata(new PropertyChangedCallback(OnPropChanged)));
    private static void OnPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ImageToggleButton tb = (ImageToggleButton)d;
        if (tb.UncheckedImage == null)
            tb.UncheckedImage = (ImageSource)e.NewValue;
    }

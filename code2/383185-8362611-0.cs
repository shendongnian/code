    public static readonly DependencyProperty VisibleProperty = DependencyProperty.Register("Visible", typeof(bool), typeof(SpecialMenuItem), new FrameworkPropertyMetadata(false, OnVisibleChanged));
    private static void OnVisibleChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        // logic here will be called whenever the Visible property changes
    }

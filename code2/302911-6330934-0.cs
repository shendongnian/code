    UIElement.IsEnabledProperty.AddOwner(typeof(MyUserControl), new FrameworkPropertyMetadata(OnIsEnabledChanged));
    public static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((MyUserControl)d).DoSomething();
    }

    private void stackPanel1_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (stackPanel1.IsVisible)
        {
            UIElement elm = stackPanel1.Children[0];
            FrameworkElement fwe = (FrameworkElement)elm;
            fwe.IsVisibleChanged += new DependencyPropertyChangedEventHandler(fwe_IsVisibleChanged);
        }
    }
    void fwe_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement fwe = (FrameworkElement)sender;
        fwe.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(fwe_IsVisibleChanged);
        Keyboard.Focus((IInputElement)sender);
    }

    public static class Initial
    {
        public static void SetFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(FocusProperty, value);
        }
        public static readonly DependencyProperty FocusProperty =
                DependencyProperty.RegisterAttached(
                 "Focus", typeof(bool), typeof(Initial),
                 new UIPropertyMetadata(false, HandleFocusPropertyChanged));
        private static void HandleFocusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (UIElement)d;
            if ((bool)e.NewValue)
                element.Focus(); // Ignore false values.
        }
    }

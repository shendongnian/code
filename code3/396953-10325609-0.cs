    private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as MySpecialTextBox;
        if (control != null)
        {
            control.SetCurrentValue(TextBox.TextProperty, SomeAdjustedValue((string)e.NewValue));
        }
    }

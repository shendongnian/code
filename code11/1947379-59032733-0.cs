    private static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    
        var numericUpDown = d as NumericUpDown;
    
        if (numericUpDown == null)
            return;
        if (((double)e.NewValue) < numericUpDown.MinValue)
        {
            numericUpDown.Value = numericUpDown.MinValue;
            return;
        }
        BindingExpression bindingExpression = numericUpDown.GetBindingExpression(NumericUpDown.ValueProperty);
        if (bindingExpression != null)
            bindingExpression.UpdateSource();
    
        ((NumericUpDown)d).txtBoxValue.Text = ((double)e.NewValue).ToString();
    }

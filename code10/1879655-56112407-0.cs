    public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register(
                    "Value",
                    typeof(int),
                    typeof(IntegerUpDown),
                    new FrameworkPropertyMetadata(0,
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                        new PropertyChangedCallback(ValuePropertyChangedCalllback),
                        new CoerceValueCallback(ValuePropertyCoerceValueCallback))
                    { DefaultUpdateSourceTrigger = UpdateSourceTrigger.Explicit });
    ...
    private static void ValuePropertyChangedCalllback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        IntegerUpDown ctrl = (IntegerUpDown)d;
        int newValue = (int)e.NewValue;
        BindingExpression be = ctrl.GetBindingExpression(ValueProperty);
        if (be != null && be.ResolvedSource != null && be.ParentBinding != null && be.ParentBinding.Path != null
            && !string.IsNullOrEmpty(be.ParentBinding.Path.Path))
        {
            var pi = be.ResolvedSource.GetType().GetProperty(be.ParentBinding.Path.Path);
            if (pi != null)
                pi.SetValue(be.ResolvedSource, newValue);
        }
        ctrl.RaiseEvent(new RoutedPropertyChangedEventArgs<int>((int)e.OldValue, newValue, ValueChangedEvent));
    }

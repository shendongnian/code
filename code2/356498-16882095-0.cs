    private static void OnMyPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        // Can also use GetBinding(), GetBindingExpression()
        // GetBindingExpressionBase() as needed.
        var binding = BindingOperations.GetBindingBase(d, e.Property);
    }

    // this will allow us to keep track of the real UpdateSourceTriggers for our bindings
    private Dictionary<BindingExpression, UpdateSourceTrigger> _deactivatedBindings = new Dictionary<BindingExpression, UpdateSourceTrigger>();
    public static void OnUnloaded(object sender, RoutedEventArgs e)
    {
        foreach(BindingExpreesion expression in GetBindingPaths(sender as DependencyObject))
            expression.DeactivateBindings();
    }
    public static void OnLoaded(object sender, RoutedEventArgs e)
    {
        foreach(BindingExpreesion expression in GetBindingPaths(sender as DependencyObject))
            expression.ReactivateBindings();
    }
    public static asynce Task DeactivateBindings(this BindingExpression oldExpression)
    {
        // you can't modify bindings once they've been used, so we'll copy the old one, modify it, and use that one instead
        Binding duplicateBinding = oldExpression.ParentBinding.Clone();
        // this means that the binding won't update when the property changes, just when we tell it to.
        duplicateBinding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
        // here we save the 'real' value - the one we use when the element is loaded.
        _deactivatedBindings[duplicateBinding] = oldExpression.ParentBinding.UpdateSourceTrigger;
        BindingOperations.SetBinding(oldExpression.Target, oldExpression.TargetProperty, duplicateBinding);
    }
    public static async Task ReactivateBindings(this BindingExpression oldExpression)
    {
        if(_deactivatedBindings.TryGetValue(oldExpression.ParentBinding, out UpdateSourceTrigger realTrigger))
        {
             _deactivatedBindings.Remove(oldExpression.ParentBinding);
             Binding duplicateBinding = oldExpression.ParentBinding.Clone();
             duplicateBinding.UpdateSourceTrigger = realTrigger;
             // This has the added advantage of refreshing the value so it's up to date. :)
             BindingOperations.SetBinding(oldExpression.Target, oldExpression.TargetProperty, duplicateBinding);
        }
    }

    public override object ProvideValue(IServiceProvider provider)
    {
        IProvideValueTarget service = (IProvideValueTarget)provider.GetService(typeof(IProvideValueTarget));
        DependencyObject targetObject = service.TargetObject as DependencyObject;
        DependencyProperty targetProperty = service.TargetProperty as DependencyProperty;
        // ...
    }

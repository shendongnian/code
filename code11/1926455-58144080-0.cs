    public static class ProvideToSource
    {
      private const string Target = nameof(Target);
      public static DependencyProperty TargetProperty = DependencyProperty.RegisterAttached(nameof(Target), typeof(object), typeof(ProvideToSource), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, ValueChanged, CoerceValue, true, UpdateSourceTrigger.Explicit));
      public static object GetTarget(DependencyObject dependent)
      {
        return dependent.GetValue(TargetProperty);
      }
      public static void SetTarget(DependencyObject dependent, object value)
      {
        dependent.SetValue(TargetProperty, value);
      }
      private const string Cache = nameof(Cache);
      private static DependencyProperty CacheProperty = DependencyProperty.RegisterAttached(nameof(Cache), typeof(object), typeof(ProvideToSource));
      private static object CoerceValue(DependencyObject dependent, object value)
      {
        if (dependent.GetValue(CacheProperty) == null)
        {
          value = GetOrCreateCachedValue(dependent);
          dependent.Dispatcher.Invoke(() => UpdateValueAndBindings(dependent, value));
        }
        return value;
      }
      private static void ValueChanged(DependencyObject dependent, DependencyPropertyChangedEventArgs args)
      {
        var cachedValue = GetOrCreateCachedValue(dependent);
        if (args.NewValue != cachedValue)
        {
          dependent.Dispatcher.Invoke(() => UpdateValueAndBindings(dependent, cachedValue));
        }
      }
      private static void UpdateValueAndBindings(DependencyObject dependent, object value)
      {
        var bindingExpression = BindingOperations.GetBindingExpression(dependent, TargetProperty);
        if (bindingExpression != null && bindingExpression.Status != BindingStatus.Detached)
        {
          bindingExpression?.UpdateTarget(); //This call seems out of place but is required
          SetTarget(dependent, value);
          bindingExpression?.UpdateSource();
        }
        else
        {
          SetTarget(dependent, value);
        }
      }
      private static object GetOrCreateCachedValue(DependencyObject dependent)
      {
        var item = dependent.GetValue(CacheProperty);
        if (item == null)
        {
          item = new ProvidedObject();  // Generate item here
          dependent.SetValue(CacheProperty, item);
        }
        return item;
      }
    }

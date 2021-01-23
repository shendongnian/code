    private static void BindProperties(FrameworkElement view, IEnumerable<PropertyInfo> properties)
    {
      foreach (var property in properties)
      {
        var foundControl = view.FindName(property.Name) as DependencyObject;
        if(foundControl == null) // find the element
          continue;
        DependencyProperty boundProperty;
        if(!_boundProperties.TryGetValue(foundControl.GetType(), out boundProperty))
          continue;
        if(((FrameworkElement)foundControl).GetBindingExpression(boundProperty) != null) // already bound
          continue;
        var binding = new Binding(property.Name) // create the binding
        {
          Mode = property.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay,
          ValidatesOnDataErrors = Attribute.GetCustomAttributes(property, typeof(ValidationAttribute), true).Any()
        };
        if (boundProperty == UIElement.VisibilityProperty && typeof(bool).IsAssignableFrom(property.PropertyType))
          binding.Converter = _booleanToVisibilityConverter;
        BindingOperations.SetBinding(foundControl, boundProperty, binding);
      }
    }

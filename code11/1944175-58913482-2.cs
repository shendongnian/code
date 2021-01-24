    public void setBinding(string propertyName, object source, FrameworkElement control, DependencyProperty dependencyProperty)
    {
        Binding binding = new Binding(propertyName);
        control.SetBinding(dependencyProperty, binding);
    }

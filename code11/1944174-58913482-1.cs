    setBinding("Labels", Labels, yAxis, Axis.LabelsProperty);
    public void setBinding(string propertyName, object source, FrameworkElement control, DependencyProperty dependencyProperty)
    {
        Binding binding = new Binding(propertyName)
        {
            Source = source
        };
        control.SetBinding(dependencyProperty, binding);
    }

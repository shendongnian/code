C#
    public static readonly DependencyProperty CustomPropertyProperty = DependencyProperty.RegisterAttached("CustomProperty", typeof(double), typeof(FrameworkElement), new PropertyMetadata(1.0));
with
C#
    public static readonly DependencyProperty CustomPropertyProperty = DependencyProperty.RegisterAttached("CustomProperty", typeof(double), typeof(FrameworkElementExtensions), new PropertyMetadata(1.0));
The key here is the `ownerType` parameter from `DependencyProperty.RegisterAttached()`. It needs to be the extension type, and not the extended one.

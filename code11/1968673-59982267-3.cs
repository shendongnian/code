    public class AQDatagridDependencyProperties : DependencyObject
    {
      public static readonly DependencyProperty CustomDataSourceProperty = DependencyProperty.RegisterAttached(
        "CustomDataSource",
        typeof(string),
        typeof(AQDatagridDependencyProperties),
        new FrameworkPropertyMetadata("obuolys", AQDatagridDependencyProperties.DebugPropertyChanged));
      private static void DebugPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
        var oldValue = e.OldValue; // Set breakpoints here
        var newValue = e.NewValue; // in order to track property changes 
      }
    
      public static void SetCustomDataSource(UIElement element, string value)
      {
        element.SetValue(CustomDataSourceProperty, value);
      }
    
      public static string GetCustomDataSource(UIElement element)
      {
        return (string) element.GetValue(CustomDataSourceProperty);
      }
    }

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
    
      public static void SetCustomDataSource(DependencyObject attachingElement, string value)
      {
        attachingElement.SetValue(CustomDataSourceProperty, value);
      }
    
      public static string GetCustomDataSource(DependencyObject attachingElement)
      {
        return (string) attachingElement.GetValue(CustomDataSourceProperty);
      }
    }

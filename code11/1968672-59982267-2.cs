    public class AQDatagridDependencyProperties : DependencyObject
    {
      public static readonly DependencyProperty CustomDataSourceProperty = DependencyProperty.RegisterAttached(
        "CustomDataSource",
        typeof(string),
        typeof(AQDatagridDependencyProperties),
        new FrameworkPropertyMetadata("obuolys"));
    
      public static void SetCustomDataSource(UIElement element, string value)
      {
        element.SetValue(CustomDataSourceProperty, value);
      }
    
      public static string GetCustomDataSource(UIElement element)
      {
        return (string) element.GetValue(CustomDataSourceProperty);
      }
    }

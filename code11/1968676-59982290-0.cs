    public class AQDatagridDependencyProperties
    {
        public static void SetCustomDataSource(AQDataGrid element, string value)
        {
            element.SetValue(CustomDataSourceProperty, value);
        }
        public static string GetCustomDataSource(AQDataGrid element)
        {
            return (string)element.GetValue(CustomDataSourceProperty);
        }
        public static readonly DependencyProperty CustomDataSourceProperty =
             DependencyProperty.RegisterAttached(
                 "CustomDataSource",
                 typeof(string),
                 typeof(AQDatagridDependencyProperties),
                 new PropertyMetadata("obuolys"));
    } 

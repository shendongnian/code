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
             DependencyProperty.RegisterAttached( // here
                 "CustomDataSource",
                 typeof(string),
                 typeof(AQDatagridDependencyProperties), // and here
                 new PropertyMetadata("obuolys"));
    } 

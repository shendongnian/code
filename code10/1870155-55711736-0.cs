    public class GridViewColumnExtensions
    {
        public static readonly DependencyProperty PathProperty = DependencyProperty.RegisterAttached(
            "Path",
            typeof(string),
            typeof(GridViewColumnExtensions),
            new FrameworkPropertyMetadata(null)
        );
        public static void SetPath(GridViewColumn element, string value)
        {
            element.SetValue(PathProperty, value);
        }
        public static string GetPath(GridViewColumn element)
        {
            return (string)element.GetValue(PathProperty);
        }
    }

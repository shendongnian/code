    public class GridExtensions
    {
        public static DependencyProperty ActiveRowProperty =
            DependencyProperty.RegisterAttached("ActiveRow",
                                                typeof(int),
                                                typeof(GridExtensions),
                                                new PropertyMetadata(-1));
        public static int GetActiveRow(DependencyObject element)
        {
            return (int)element.GetValue(ActiveRowProperty);
        }
        public static void SetActiveRow(DependencyObject element, int value)
        {
            element.SetValue(ActiveRowProperty, value);
        }
    }

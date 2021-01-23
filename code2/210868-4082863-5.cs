    public partial class MainWindow : Window
    {
        private static readonly DependencyProperty WrapColumnProperty =
              DependencyProperty.RegisterAttached("WrapColumn",
                                                  typeof(bool),
                                                  typeof(MainWindow));
        public static void SetWrapColumn(DependencyObject element, bool value)
        {
            element.SetValue(WrapColumnProperty, value);
        }
        public static bool GetWrapColumn(DependencyObject element)
        {
            return (bool)element.GetValue(WrapColumnProperty);
        }

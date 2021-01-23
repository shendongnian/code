    public class SeparatorConverter : IValueConverter
    {
        private Visibility _visible;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var element = (TextBlock) value;
            element.Loaded += ElementLoaded;
            return _visible;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null; //not needed
        }
        private static void ElementLoaded(object sender, RoutedEventArgs e)
        {
            var element = sender as TextBlock;
            var parentItemsControl = element.FindParent(x => x is ItemsControl) as ItemsControl;
            var parentPanel = element.FindParent(x => x is Panel) as Panel;
            if (parentItemsControl == null || element == null || parentPanel== null)
                return;
            var itemText = parentPanel.FindName("MyTextBlock") as TextBlock;
            var collection = parentItemsControl.ItemsSource as IEnumerable<string>;
            if (itemText == null || collection == null)
                return;
            var list = collection.ToList();
            if (list.IndexOf(itemText.Text) == list.Count() - 1) // Can be incorrect because we can have two same items
               element.Visibility = Visibility.Collapsed;
        }
    }

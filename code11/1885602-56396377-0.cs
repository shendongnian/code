    public class RadioGroupIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ListViewItem lvi)
            {
                var listView = ItemsControl.ItemsControlFromItemContainer(lvi);
                var index = listView.ItemContainerGenerator.IndexFromContainer(lvi);
                return string.Format("{0}{1}", parameter, index);
            }
            return parameter;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

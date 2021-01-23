    public class IndexOfConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (Designer.IsInDesignMode) return false;
            var itemsControl = values[0] as ItemsControl;
            var item = values[1];
            var itemContainer = itemsControl.ItemContainerGenerator.ContainerFromItem(item);
            // It may not yet be in the collection...
            if (itemContainer == null)
            {
                return Binding.DoNothing;
            }
            var itemIndex = itemsControl.ItemContainerGenerator.IndexFromContainer(itemContainer);
            return itemIndex;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return targetTypes.Select(t => Binding.DoNothing).ToArray();
        }
    }

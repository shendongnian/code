    public class TreeViewItemToLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DependencyObject))
                return 0;
    
            return findLevel(value as DependencyObject, -1);
        }
    
        private int findLevel(DependencyObject tvi, int level)
        {
            DependencyObject tv = ItemsControl.ItemsControlFromItemContainer(tvi) as DependencyObject;
    
            if (tv != null)
                return findLevel(tv, level + 1);
            else
                return level;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    public class ExpandableGroupNameConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new ExpandableGroupName { Name = value };
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var groupName = value as ExpandableGroupName;
            if (groupName != null)
                return groupName.Name;
            return Binding.DoNothing;
        }
        #endregion
    }

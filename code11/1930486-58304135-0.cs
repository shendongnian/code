    public sealed class ItemIndexConverter : IMultiValueConverter
    {
        public object Convert(object[] dataItems, Type targetType, object props, CultureInfo _) => 
            ((IList)dataItems[1]).IndexOf(dataItems[0]).ToString();
        public object[] ConvertBack(object value, Type[] targetTypes, object props, CultureInfo _) =>
            throw new NotImplementedException();
    }

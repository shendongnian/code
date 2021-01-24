    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IList genericCollection = value as IList;
            int index = System.Convert.ToInt32(parameter);
            if (genericCollection.Count > index)
            {
                object collection = genericCollection[index];
                if (collection != null)
                    return collection;
            }
            return Binding.DoNothing;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

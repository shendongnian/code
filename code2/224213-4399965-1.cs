    public class EnumerableToObservableCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            if (targetType != typeof(ObservableCollection))
            {
                throw new ArgumentException("Do not use this converter except " +
                    "when going to ObservableCollection");
            }
            var enumerable = value as IEnumerable;
            if (null == enumerable)
            {
                return new ObservableCollection();
            }
            return new ObservableCollection(enumerable);
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class AreAllValuesEqualConverter<T> : IMultiValueConverter
    {
        public T EqualValue { get; set; }
        public T NotEqualValue { get; set; }
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            T returnValue;
            if (values.Length < 2)
            {
                returnValue = EqualValue;
            }
            // Need to use .Equals() instead of == so that string comparison works, but must check for null first.
            else if (values[0] == null)
            {
                returnValue = (values.All(v => v == null)) ? EqualValue : NotEqualValue;
            }
            else
            {
                returnValue = (values.All(v => values[0].Equals(v))) ? EqualValue : NotEqualValue;
            }
            return returnValue;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    [ValueConversion(typeof(object), typeof(Boolean))]
    public class AllValuesEqualToBooleanConverter : AreAllValuesEqualConverter<Boolean>
    { }

    public class MyConverter : IMultiValueConverter {
    
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return System.Convert.ToString(values[0]);
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) {
            // Get the type of the value, but assume string if it's null
            Type valueType = typeof(string);
            if (value != null)
                valueType = value.GetType();
    
            // Convert value to the various target types using the default TypeConverter
            object[] values = new object[targetTypes.Length];
            for (int i = 0; i < values.Length; i++) {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(targetTypes[i]);
                if (typeConverter != null && typeConverter.CanConvertFrom(valueType))
                    values[i] = typeConverter.ConvertFrom(value);
                else
                    values[i] = value;
            }
            return values;
        }
    
    }

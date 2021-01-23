    public class MyStringToPointCollectionConverter : TypeConverter {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            if (sourceType == typeof(string)) {
                return true;
            }
    
            return false;
        }
    
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
            var stringValue = value as string;
    
            if (stringValue != null) {
                var result = new ObservableCollection<Point>();
    
                // Here goes the logic of converting the given string to the list of points
    
                return result;
            }
    
            return null;
        }
    }

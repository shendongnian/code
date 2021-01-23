    public class DateConverter : IValueConverter{
        public object Convert(object value, Type targetType, object parameter, CultureInfo    culture)
        {
        if(null == value){
           return null;
        }else if(value is Stream){
           return value;
        }else{
           throw new InvalidOperationException("Unsupported type");
        }
        ....

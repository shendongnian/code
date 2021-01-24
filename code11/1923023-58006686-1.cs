      public class InvertedBooleanConverter : MarkupExtension, IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
    
          if (value == null || (bool)value == false)
            return true;
          else
            return false;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          if (value == null || (bool)value == false)
            return true;
          else
            return false;
        }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
          return this;
        }
      }

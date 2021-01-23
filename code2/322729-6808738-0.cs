    public class BooleanToVisibilityConverterExtension : MarkupExtension, IValueConverter
    {
      private BooleanToVisibilityConverter converter;
    
      public BooleanToVisibilityCoverterExtension() : base()
      {
        this.converter = new BooleanToVisibilityConverter();
      }
    
      public override object ProvideValue(IServiceProvider serviceProvider)
      {
        return this;
      }
    
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
        return this.converter.Convert(value, targetType, parameter, culture);
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
        return this.converter.ConvertBack(value, targetType, parameter, culture);
      }
    }

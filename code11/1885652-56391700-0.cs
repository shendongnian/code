    public class CellUnitConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public string Unit { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Checks both if the value is null or if the converter somehow gets used ahead of time
            if (value == null || value == DependencyProperty.UnsetValue)
            {
                return string.Empty;
            }
            // You can place some rounding rules here
            return $"{value} {Unit}";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

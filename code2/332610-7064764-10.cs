    public class MyConverter : DependencyObject, IValueConverter
    {
        public static DependencyProperty SourceValueProperty =
            DependencyProperty.Register("SourceValue",
                                        typeof(string),
                                        typeof(MyConverter));
        public string SourceValue
        {
            get { return (string)GetValue(SourceValueProperty); }
            set { SetValue(SourceValueProperty, value); }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //...
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object targetValue = value;
            object sourceValue = SourceValue;
            //...
        }
    }

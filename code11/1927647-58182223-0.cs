    namespace App2.Converters
    {
        class MyConverter : BindableObject, IValueConverter
        {
            public static readonly BindableProperty ConvParamProperty = BindableProperty.Create(nameof(ConvParam), typeof(int), typeof(MyConverter));
            public int ConvParam
            {
                get { return (int)GetValue(ConvParamProperty); }
                set { SetValue(ConvParamProperty, value); }
            }
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return $"value: {value} - ConvParam: {ConvParam}";
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }

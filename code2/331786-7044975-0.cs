    <local:NumberToBrushConverter x:Key="numberToBrushConverter" />
    <local:NumberToTextConverter x:Key="numberToTextConverter" />
    
    <TextBlock Background="{Binding Number, Converter={StaticResource numberToBrushConverter}}"                    
    Text="{Binding Number, Converter={StaticResource numberToTextConverter}"/>
----------
    class NumberToBrushConverter: IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int number = (int)value;
            return number < 80 ? Brushes.Red : Brushes.Green;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
        #endregion
    }

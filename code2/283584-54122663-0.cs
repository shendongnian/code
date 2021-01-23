    [ValueConversion(typeof(DateTime), typeof(String))]
        class DateTimeToLocalConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (!(value is DateTime)) return "Invalid DateTime";
                DateTime DateTime = (DateTime)value;
                return DateTime.ToLocalTime().ToShortDateString();
    
            }
    
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            
        }

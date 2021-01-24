    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        DateTime? dt = (DateTime?)value;
        if (!dt.HasValue)
            return new SolidColorBrush(Colors.Black);
        DateTime date = dt.Value.Date;
        if (date == DateTime.Today)
            return new SolidColorBrush(Colors.Yellow);
        else if (date < DateTime.Today)
            return new SolidColorBrush(Colors.Red);
        else if (date > DateTime.Today)
            return new SolidColorBrush(Colors.Blue);
        return new SolidColorBrush(Colors.Black);
    }

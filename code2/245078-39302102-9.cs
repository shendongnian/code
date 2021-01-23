    class AngleToPointConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double angle = (double)values[0];
            double radius = 50;
            double piang = angle * Math.PI / 180;
            double px = Math.Sin(piang) * radius + radius;
            double py = -Math.Cos(piang) * radius + radius;
            return new Point(px, py);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

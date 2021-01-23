    public class PointsToPointsCollectionsConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var points = value as List<Point>;
            if (points != null)
            {
                var pc = new PointCollection();
                foreach (var point in points)
                {
                    pc.Add(point);
                }
                return pc;
            }
            else return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

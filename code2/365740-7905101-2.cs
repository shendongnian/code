    public class PointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                double val = (double)value;
                int num = int.Parse("" + parameter);
                if (num == 1)
                {
                    if (val < 50) return new Point(200 - val * 4, 200);
                    else return new Point(0, 200 - (val - 50) * 4);
                }
                else if (num == 2)
                {
                    if (val < 50) return new Point(200 - val * 4, 200);
                    else return new Point(0, 200);
                }
                else if (num == 3)
                {
                    return new Point(200, 200);
                }
                else if (num == 4)
                {
                    return new Point(200, 100);
                }
                else if (num == 5)
                {
                    if (val < 25) return new Point(200 - val * 4, 100);
                    else return new Point(100, 100);
                }
                else if (num == 6)
                {
                    if (val < 25) return new Point(200 - val * 4, 100);
                    else if (val < 75) return new Point(100, 100);
                    else return new Point(100, 200 - (val - 50) * 4);
                }
            }
            catch { }
            return new Point();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

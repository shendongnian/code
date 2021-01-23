    public class StringToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var hexString = (value as string).Replace("#", "");
            if (string.IsNullOrWhiteSpace(hexString)) throw new FormatException();
            if (hexString.Length != 6 || hexString.Length != 8) throw new FormatException();
            try
            {
                var a = hexString.Length == 8 ? hexString.Substring(0, 2) : "255";
                var r = hexString.Length == 8 ? hexString.Substring(2, 2) : hexString.Substring(0, 2);
                var g = hexString.Length == 8 ? hexString.Substring(4, 2) : hexString.Substring(2, 2);
                var b = hexString.Length == 8 ? hexString.Substring(6, 2) : hexString.Substring(4, 2);
                return new SolidColorBrush(ColorHelper.FromArgb(
                    byte.Parse(a, System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(r, System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(g, System.Globalization.NumberStyles.HexNumber),
                    byte.Parse(b, System.Globalization.NumberStyles.HexNumber)));
            }
            catch
            {
                throw new FormatException();
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

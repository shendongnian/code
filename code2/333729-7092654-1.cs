    public class Date2AxisConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is DateTime && targetType == typeof(double))
            {
                return ((DateTime)value).Ticks / 10000000000.0;
                // See constructor of class Microsoft.Research.DynamicDataDisplay.Charts.DateTimeAxis
                // File: DynamicDataDisplay.Charts.Axes.DateTime.DateTimeAxis.cs
                // alternatively, see the internal class Microsoft.Research.DynamicDataDisplay.Charts.DateTimeToDoubleConversion
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // try Microsoft.Research.DynamicDataDisplay.Charts.DateTimeAxis.DoubleToDate
            throw new NotSupportedException();
        }
        #endregion
    }

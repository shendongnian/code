    public class StatusConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int statusId = (int)values[0];
            IEnumerable<TheStatus> statuses = (IEnumerable<TheStatus>)values[1];
            return statuses.FirstOrDefault(x => x.Status_ID == statusId)?.Status;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

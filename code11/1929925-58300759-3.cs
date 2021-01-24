    public class GetListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return null;
            }
            ObservableCollection<string> dataList = MainViewModel.GetInstance().SubtasksList[int.Parse((string)value) - 1];
            return dataList;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

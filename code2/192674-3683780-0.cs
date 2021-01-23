    public sealed class CountToStringConverter : System.Windows.Data.IValueConverter {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            ObservableCollection<CustomClass> items = value as ObservableCollection<CustomClass>;
            int count = 0;
            foreach (var item in items) {
                if (item.IsChecked) {
                    count++;
                }
            }
            return count + " Items";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
        #endregion
    }

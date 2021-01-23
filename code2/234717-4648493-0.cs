    public class StateToBackgroundColorConverter : IValueConverter
      {
        #region IValueConverter Members
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          if (value == null) return Colors.White.ToString();
    
          var state = (State) value;
          return state.WebColor;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          throw new NotImplementedException();
        }
    
        #endregion
      }

      public class NextEnabled : IValueConverter
      {
       protected Window window_main;
       public NextEnabled(Window w) { window_main = w; }
       public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
       {
    
        return window_main.Adam;
       }
    
       public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
       {
        return true;
       }
      }

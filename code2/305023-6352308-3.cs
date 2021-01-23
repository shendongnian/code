      public class MyFileExtensionConverter : IValueConverter {  
          public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
             Boolean returnValue = false;  
      
             String fileExtension = parameter as String;
             String fileName = value as String;
    
             if (String.IsNullOrEmpty(fileName)) { }
             else if (String.IsNullOrEmpty(fileExtension)) { }
             else if (String.Compare(Path.GetExtension(fileName), fileExtension, StringComparison.OrdinalIgnoreCase) == 0) {
                returnValue = true;
             }
             return returnValue;
          }
    
          public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
             return value;
          }
       }

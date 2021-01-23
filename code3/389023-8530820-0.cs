    public class MyValueConverter : IValueConverter    {        
     
    /*
    Implement this method to modify the source data before sending it to display
    */
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)        {
                try            {
                   return new BitmapImage(new Uri("../Images/" + (string)(value), UriKind.Relative));
                }
                catch{
                    return new BitmapImage();
                }
            }
     /*
    Implement this method to modify the target data before sending it back to the source.
    */
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)        { 
                var img = value as BitmapImage;
                return img.UriSource.AbsoluteUri;
            }
     
        }
 

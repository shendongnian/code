    public class TestConverter : IValueConverter
    {
                
                object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    
                  
                    Institution inst = (Institution)DataMapper.institutions[(int)value];
        
                    return inst.Name;
                }
        
                object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
    }

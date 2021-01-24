    public class ColorConvert : IValueConverter
        {
            // this does not include sublevel menus right now
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                if (value.ToString() == "False")
                {
                    return Helper.BlackBrush;
                }
                else
                {
                    return Helper.GetHighlightBrush();
                }
    
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException(); 
            }
        }

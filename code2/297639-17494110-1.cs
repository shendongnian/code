    public class BGConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Foo foo = (Foo)value;
            string bgColor = "Gray";
            switch(foo.Status)
            {
                case 0: 
                    bgColor = "White";
                    break;
                case 1: 
                    bgColor = "Cyan";
                    break;
                case 2: 
                    bgColor = "Yellow";
                    break;
            }
            return bgColor;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class FSConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Foo foo = (Foo)value;
            string fStyle = "Normal";
            switch(foo.Status)
            {
                case 0:
                    fStyle = "Normal";
                    break;
                case 1: 
                    fStyle = "Oblique";
                    break;
                case 2: 
                    fStyle = "Italic";
                    break;
            }
            return fStyle;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class FGConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Foo foo = (Foo)value;
            string fgColor = "Black";
            switch(foo.Status)
            {
                case 0: 
                    fgColor = "Blue";
                    break;
                case 1: 
                    fgColor = "Brown";
                    break;
                case 2: 
                    fgColor = "DarkBlue";
                    break;
            }
            return fgColor;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
        
    public class TTipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Foo foo = (Foo)value;
            string ttText = "No tool tips for this item.";
            switch(foo.Status)
            {
                case 0: 
                    ttText = "The item has not been processed";
                    break;
                case 1: 
                    ttText = "The item has been processed but not saved";
                    break;
                case 2: 
                    ttText = "The item has been processed and saved";
                    break;
            }
            return ttText ;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CategoryImageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var name = (string)value;
    
            switch (name)
            {
                case "Entradas":
                    return "entradas.png";
                case "Carnes":
                    return "carnes.png";
                case "Peixes":
                    return "peixes.png";
    
                // add more here
            }
    
            return null;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

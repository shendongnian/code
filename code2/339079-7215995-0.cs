    class EntradasToVisibilityConverter : IValueConverter
    {
        public Object Convert(
    	Object value,
    	Type targetType,
    	Object parameter,
    	CultureInfo culture )
        {
            // error checking, make sure 'value' is of type
            // Entradas, make sure 'targetType' is of type 'Visibility', etc.
    
            return (((Entradas)value) == Entradas.Entero) 
                    ? Visibility.Visible
                    : Visibility.Collapsed;
        }
    
        public object ConvertBack(
    	object value,
    	Type targetType,
    	object parameter,
    	CultureInfo culture )
        {
            // you probably don't need a conversion from Visibility
            // to Entradas, but if you do do it here
            return null;
        }
    }

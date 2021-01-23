    [ValueConversion(typeof(Quality), typeof(Brush))]
    public class QualityToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
    		if (value != null)
    		{
    			Quality quality = (Quality)value;			
    			switch (quality)
    			{
    				case 0: return Brushes.Red;
    				case 1: return Brushes.Yellow;
    				case 2: return Brushes.Green;
    				default: return Brushes.Transparent;
    			}	
    		}
            return Brushes.Transparent;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw NotImplementedException();
        }
    }

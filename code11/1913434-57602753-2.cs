    public class PositiveNegativeConverter :  IValueConverter
    {
        public object Convert(object Stock, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (Stock==null)
            {
                Stock = "";
            }
            string Stocks = Stock.ToString();
            bool revert = (Stocks as string).StartsWith("-");
            string stringValue = Stock as string;
            string compareValue = parameter as string;
            if (revert)
            {
                
                return Brushes.Tomato;
               
            }
            else
                return Brushes.LimeGreen;
          
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

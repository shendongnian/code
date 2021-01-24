       public class AddListRecordsConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                decimal val = 0;
                decimal result = 0;
    
                foreach (var txt in values)
                {
                    if (string.IsNullOrEmpty(txt.ToString())) continue;
                    if (decimal.TryParse(txt.ToString(), out val))
                        result += val;
                    else
                        return "$0.00";
                }
    
                return result.ToString();
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                return null;
            }
        }
    public class InterestCalculationRecordsConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                decimal val = 0;
                decimal result = 0;
                List<decimal> convertedLists = new List<decimal>();
                foreach (var txt in values)
                {
                    if (string.IsNullOrEmpty(txt.ToString())) return null;
                    if (decimal.TryParse(txt.ToString(), out val))
                        //result += val;
                        convertedLists.Add(val);
                    else
                        return "$0.00";
                }
    
                if (convertedLists[0] == 0) return 0;
                result = 1 / convertedLists[0] * convertedLists[1] * convertedLists[2] * convertedLists[3];
    
                return result.ToString();
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                return null;
            }
        }

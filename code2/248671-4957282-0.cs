    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Data;
    
    namespace XAMLConverter
    {
        public class ComboBoxConverter : IValueConverter
        {
    
           
            object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {                
                    if (value.ToString() == "Yes")
                        return "Cleared";
                    else if (value.ToString() == "No")
                        return "Not Cleared";
                    else
                        return "";
                    
                }
                catch
                {
                    return "";
                }
            }
    
            object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }

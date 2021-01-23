    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Data;
    using QUPS.Data;
    using QUPS.Data.QUPSModel;
    
    namespace QUPS.Helpers
    {
        public class EntityObjectToDecimalConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter,
                                  CultureInfo culture)
            {
                if (value is IQUPSEntityObject)
                {
                    var rec = (IQUPSEntityObject)value;
                    return rec.ID;
                }
    
                return value;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter,
                                      CultureInfo culture)
            {
                if (value is IQUPSEntityObject)
                {
                    var rec = (IQUPSEntityObject)value;
                    return rec.ID;
                }
    
                return value;
            }
        }
    }

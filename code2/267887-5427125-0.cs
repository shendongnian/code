    public sealed class DataSetConverter : IValueConverter
        {
    
            #region IValueConverter Members
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
               if((DataSet)value != null)
    {
    
    // Put logic in here to loop through the columns and create an object to bind to the ListView control.
    
    }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }

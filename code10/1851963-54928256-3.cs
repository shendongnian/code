     public class SummUp: IValueConverter
    {
        #region Convert
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var rtn = 0;
            var coll = (value as ObservableCollection<OverView>);
            var param = System.Convert.ToInt32(parameter);
            foreach (var item in coll)
            {
                if (param == 1)
                {
                    rtn += item.LicenseCount;
                }
                else if (param == 2)
                {
                    rtn += item.ScansCount;
                }
            }
            return rtn;
        }//END Convert
        #endregion Convert
        #region ConvertBack
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }//END ConvertBack 
        #endregion ConvertBack 
    }//END class boolToNotVisibilityConverter : IValueConverter 

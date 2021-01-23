    public class ArrayConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = value as CellModel[,];
            if (val == null) return null;
            return ToEnumerable(val);
        }
        private IEnumerable<IEnumerable<CellModel>> ToEnumerable(CellModel[,] array)
        {
            var count = array.GetLength(0);
            
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                yield return GetLine(array, i);
            }
        }
        private IEnumerable<CellModel> GetLine(CellModel[,] array, int line)
        {
            var count = array.GetLength(1);
            for (int i = 0; i < count; ++i)
            {
                yield return array[line, i];
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

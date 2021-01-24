    class CellForegroundMultiValueConverter : IMultiValueConverter
    {
      #region Implementation of IMultiValueConverter
      /// <inheritdoc />
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
        var columnHeader = values[0] as string;
        var dataItem = values[1] as Result;
        return columnHeader.Equals("Column1", StringComparison.OrdinalIgnoreCase) 
               && dataItem.C1.Equals("....", StringComparison.OrdinalIgnoreCase)
          || columnHeader.Equals("Column2", StringComparison.OrdinalIgnoreCase) 
               && dataItem.C2.Equals("....", StringComparison.OrdinalIgnoreCase)
          ? Brushes.Red
          : Brushes.Black;
      }
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();
      #endregion
    }

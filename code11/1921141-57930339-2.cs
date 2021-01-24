    class DataRowViewToCellDataConverter : IMultiValueConverter
    {
      #region Implementation of IMultiValueConverter
    
      /// <inheritdoc />
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
        if (values[0] is DataRowView dataRowView 
            && ((int) values[1]) is int cellIndex
            && dataRowView[cellIndex] is CellDataModel cellModel)
        {
          return cellModel.Data;
        }
    
        return Binding.DoNothing;
      }
    
      /// <inheritdoc />
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
        throw new NotSupportedException();
    
      #endregion
    }

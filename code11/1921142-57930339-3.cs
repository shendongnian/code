    class RowDataToRowNumberConverter : IMultiValueConverter
    {
      #region Implementation of IMultiValueConverter
    
      /// <inheritdoc />
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
        if (values[0] is DataGrid dataGrid && values[1] is object rowData)
        {
          return dataGrid.Items.IndexOf(rowData) + 1;
        }
    
        return Binding.DoNothing;
      }
    
      /// <inheritdoc />
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
        throw new NotSupportedException();
    
      #endregion
    }

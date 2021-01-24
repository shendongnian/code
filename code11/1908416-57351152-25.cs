    class IsDirtyToStringConverter : IMultiValueConverter
    {
      #region Implementation of IMultiValueConverter
    
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
        if (values[0] is EmployeeViewModel viewModel && values[1] is bool modelIsDirty)
        {
          return string.Format("{0} {1}{2}", 
            viewModel.Firstname, 
            viewModel.Surname, 
            modelIsDirty 
              ? "*" 
              : string.Empty);
        }
    
        return Binding.DoNothing;
      }
    
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
      {
        throw new NotSupportedException();
      }
    
      #endregion
    }
    

    [ValueConversion(typeof(ListBoxItem), typeof(bool))]
    class ItemCountToBoolenaConverter : IValueConverter
    {
      public int MaxCount { get; set; }
    
      #region Implementation of IValueConverter
    
      /// <inheritdoc />
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
        if (value is ListBoxItem itemContainer && TryFindParentElement(itemContainer, out ItemsControl parentItemsControl))
    
        {
          return parentItemsControl.Items.IndexOf(itemContainer.Content) < this.MaxCount;
        }
    
        return Binding.DoNothing;
      }
    
      /// <inheritdoc />
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
        throw new NotSupportedException();
      }
    
      #endregion
    
      // Consider to make this an Extension Method for DependencyObject
      private bool TryFindVisualParent<TParent>(DependencyObject child, out TParent resultElement) where TParent : DependencyObject
      {
        resultElement = null;
    
        if (child == null)
          return false;
    
        DependencyObject parentElement = VisualTreeHelper.GetParent(child);         
    
        if (parentElement is TParent)
        {
          resultElement = parentElement as TParent;
          return true;
        }
    
         return TryFindVisualParent(parentElement, out resultElement);
      }
    }

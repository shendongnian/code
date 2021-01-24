    class Sort : DependencyObject
    {
      #region IsEnabled attached property
    
      public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(
        "IsEnabled", typeof(bool), typeof(Sort), new PropertyMetadata(default(bool), Sort.OnIsEnabled));
    
      public static void SetIsEnabled([NotNull] DependencyObject attachingElement, bool value) => attachingElement.SetValue(Sort.IsEnabledProperty, value);
    
      public static bool GetIsEnabled([NotNull] DependencyObject attachingElement) => (bool) attachingElement.GetValue(Sort.IsEnabledProperty);
    
      #endregion
    
      private static void OnIsEnabled(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
        bool isSortingEnabled = (bool) e.NewValue;
        if (isSortingEnabled == (bool) e.OldValue)
        {
          return;
        }
      
        if (d is GridViewColumnHeader columnHeader)
        {
          if (isSortingEnabled)
          {
            columnHeader.Click += Sort.SortByColumn;
          }
          else
          {
            columnHeader.Click -= Sort.SortByColumn;
          }  
        }
      }
    
      private static void SortByColumn(object sender, RoutedEventArgs e)
      {
        var columnHeader = sender as GridViewColumnHeader;
        PropertyPath columnSourceProperty = (columnHeader.Column.DisplayMemberBinding as Binding).Path;
    
        // Use an extension method to find the parent ListView 
        // by traversing the visual tree
        if (columnHeader.TryFindVisualParentElement(out ListView parentListView))
        {
          var collectionView = (CollectionView)CollectionViewSource.GetDefaultView(parentListView.ItemsSource);
          collectionView.SortDescriptions.Clear();
          // Apply sorting
          collectionView.SortDescriptions.Add(new SortDescription(columnSourceProperty.Path, ListSortDirection.Ascending));
        }
      }
    }

          public RelayCommand<SelectionChangedEventArgs> VideoPivotClicked
      {
          get;
          private set;
      }
    VideoPivotClicked = new RelayCommand<SelectionChangedEventArgs>(arg =>
                                                           {
                                                               PivotItem pivotItem = arg.AddedItems[0] as PivotItem;
                                                               Pivot pivot = pivotItem.Parent as Pivot;
                                                               Debug.WriteLine(pivot.SelectedIndex);
                                                           }
              );

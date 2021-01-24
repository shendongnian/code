    if (e.Key == Key.Enter)
                {
       if (Keyboard.FocusedElement is UIElement elementWithFocus)
                    {
                        switch (dvDataGrid.CurrentCell.Column.DisplayIndex)
                        {
                                case 1:
                                DataGridRow currentrow5 = dvDataGrid.ItemContainerGenerator.ContainerFromItem(dvDataGrid.CurrentItem) as DataGridRow;
                                elementWithFocus.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));                             
                                break;
                                case 2:
                                DataGridRow currentrow5 = dvDataGrid.ItemContainerGenerator.ContainerFromItem(dvDataGrid.CurrentItem) as DataGridRow;
                                elementWithFocus.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));                             
                                break;
                                case n:
                                if (dvDataGrid.ItemsSource is ObservableCollection<DetailinfoModel> itemsSourcelast)
                                {
                                    DataGridRow currentrow35 = dvDataGrid.ItemContainerGenerator.ContainerFromItem(dvDataGrid.CurrentItem) as DataGridRow;
                                    var newItem = new DetailinfoModel();
                                    itemsSourcelast.Add(newItem);
                                    dvDataGrid.SelectedItem = newItem;
                                    Dispatcher.BeginInvoke(new Action(() =>
                                    {
                                        DataGridRow newRow = dvDataGrid.ItemContainerGenerator.ContainerFromItem(newItem) as DataGridRow;
                                        DataGridCell cell = Helper.Helper.GetCell(dvSalesEntryDataGrid, newRow, 1);
                                        if (cell != null)
                                            dvDataGrid.CurrentCell = new DataGridCellInfo(cell);
                                    }), DispatcherPriority.Background);
                                    }
                                break;                               break;
                                default:
                                DataGridRow CurrentRowsdeault = dvDataGrid.ItemContainerGenerator.ContainerFromItem(dvDataGrid.CurrentItem) as DataGridRow;
                                elementWithFocus.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));  
                                break;
              }
      }
}

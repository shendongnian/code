    private void dummyCell_MoveToNextColumn(object sender, RoutedEventArgs e) {
			e.Handled = true;
			// Cell is the model object containing the parsing rules and raising events
			var lSender = sender as Cell;
			var gridItems = ViewGridReference.Items;
            var lastItem = gridItems[gridItems.Count - 1];
			if (lSender == lastItem) {
				// We are at the bottom of the column
				// Move the program on to the next column
				CurrentColumn++;
				OnPropertyChanged("ItemPositions");
			} else {
				// Simulate "empty position" input for this cell and all cells down the column
				// Cells are validating themselves as the simulation progresses
								
				foreach (Cell item in ViewGridReference.Items) {
					item.ActualItemCode = string.Empty;
				}
				
				ViewGridReference.SelectedIndex = gridItems.Count - 1;
				ViewGridReference.CurrentCell = new DataGridCellInfo(lastItem, ViewGridReference.Columns[0]);
				
				(ViewGridReference.ItemsSource as ListCollectionView).EditItem(ViewGridReference.SelectedItem);
				((DataGridCell)ViewGridReference.SelectedItem).Focus();											
			}                                   
		}

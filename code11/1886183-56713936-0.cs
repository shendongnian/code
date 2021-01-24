    {
        DataGrid.LoadingRow += DataGrid_LoadingRow;
    }
	private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
	{
		// The visual tree is not built until the row is "loaded". This event fires when this happend:
		e.Row.Loaded += DataGrid_Row_Loaded;
	}
	private void DataGrid_Row_Loaded(object sender, RoutedEventArgs e)
	{
		DataGridRow dataGridRow = (DataGridRow)sender;
		// important: Remove the event again
		dataGridRow.Loaded -= DataGrid_Row_Loaded;
		NestedGridFieldProperty ngrProp = (NestedGridFieldProperty)dataGridRow.Item;
		// Get the "presenter", which contains the cells
		DataGridCellsPresenter presenter = coNeboTools.ConeboMisc.GetVisualChild<DataGridCellsPresenter>(dataGridRow);
		
		// Get the cells in the presenter
		var cells = GetVisualChildren<DataGridCell>(presenter);
		
		// Get the underlying TextBlock in column 0
		TextBlock underlyingTextBlock = (TextBlock)cells.ElementAt(0).Content;
		
		// the Item property of the row contains the row data
		var myData = dataGridRow.Item;
		
		// do what ever is needed with the TextBlock
		underlyingTextBlock.Foreground = Brushes.Red;
	}
		// Static helper method to handle the visual tree
        public static IEnumerable<T> GetVisualChildren<T>(DependencyObject dependencyObject)
               where T : DependencyObject
        {
            if (dependencyObject != null)
            {
                int childrenCount = VisualTreeHelper.GetChildrenCount(dependencyObject);
                for (int i = 0; i < childrenCount; i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in GetVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
		// Static helper method to handle the visual tree
        public static childItem GetVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in GetVisualChildren<childItem>(obj))
            {
                return child;
            }
            return null;
        }

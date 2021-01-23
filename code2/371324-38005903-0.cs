    public static class DataGridExtensions
    {
        public static void FastEdit(this DataGrid dataGrid)
        {
            dataGrid.ThrowIfNull(nameof(dataGrid));
            dataGrid.PreviewMouseLeftButtonDown += (sender, args) => { FastEdit(args.OriginalSource, args); };
        }
        private static void FastEdit(object source, RoutedEventArgs args)
        {
            var dataGridCell = (source as UIElement)?.FindVisualParent<DataGridCell>();
            if (dataGridCell == null || dataGridCell.IsEditing || dataGridCell.IsReadOnly)
            {
                return;
            }
            var dataGrid = dataGridCell.FindVisualParent<DataGrid>();
            if (dataGrid == null)
            {
                return;
            }
            if (!dataGridCell.IsFocused)
            {
                dataGridCell.Focus();
            }
            if (dataGridCell.Content is CheckBox)
            {
                if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
                {
                    if (!dataGridCell.IsSelected)
                    {
                        dataGridCell.IsSelected = true;
                    }
                }
                else
                {
                    var dataGridRow = dataGridCell.FindVisualParent<DataGridRow>();
                    if (dataGridRow != null && !dataGridRow.IsSelected)
                    {
                        dataGridRow.IsSelected = true;
                    }
                }
            }
            else
            {
                dataGrid.BeginEdit(args);
                dataGridCell.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() => { }));
            }
        }
    }
    public static class UIElementExtensions
    {
        public static T FindVisualParent<T>(this UIElement element)
            where T : UIElement
        {
            UIElement currentElement = element;
            while (currentElement != null)
            {
                var correctlyTyped = currentElement as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }
                currentElement = VisualTreeHelper.GetParent(currentElement) as UIElement;
            }
            return null;
        }
    }

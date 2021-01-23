        private void DataGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is DataGridCell) && !(dep is DataGridColumnHeader))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null)
                return;
            if (dep is DataGridColumnHeader)
            {
                DataGridColumnHeader columnHeader = dep as DataGridColumnHeader;
                // find the property that this cell's column is bound to
                string boundPropertyName = FindBoundProperty(columnHeader.Column);
                int columnIndex = columnHeader.Column.DisplayIndex;
                ClickedItemDisplay.Text = string.Format(
                    "Header clicked [{0}] = {1}",
                    columnIndex, boundPropertyName);
            }
            if (dep is DataGridCell)
            {
                DataGridCell cell = dep as DataGridCell;
                // navigate further up the tree
                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                if (dep == null)
                    return;
                DataGridRow row = dep as DataGridRow;
                object value = ExtractBoundValue(row, cell);
                int columnIndex = cell.Column.DisplayIndex;
                int rowIndex = FindRowIndex(row);
                ClickedItemDisplay.Text = string.Format(
                    "Cell clicked [{0}, {1}] = {2}",
                    rowIndex, columnIndex, value.ToString());
            }
        }
        /// <summary>
        /// Determine the index of a DataGridRow
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private int FindRowIndex(DataGridRow row)
        {
            DataGrid dataGrid = ItemsControl.ItemsControlFromItemContainer(row) as DataGrid;
            int index = dataGrid.ItemContainerGenerator.IndexFromContainer(row);
            return index;
        }
        /// <summary>
        /// Find the value that is bound to a DataGridCell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private object ExtractBoundValue(DataGridRow row, DataGridCell cell)
        {
            // find the property that this cell's column is bound to
            string boundPropertyName = FindBoundProperty(cell.Column);
            // find the object that is realted to this row
            object data = row.Item;
            // extract the property value
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(data);
            PropertyDescriptor property = properties[boundPropertyName];
            object value = property.GetValue(data);
            return value;
        }
        /// <summary>
        /// Find the name of the property which is bound to the given column
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        private string FindBoundProperty(DataGridColumn col)
        {
            DataGridBoundColumn boundColumn = col as DataGridBoundColumn;
            // find the property that this column is bound to
            Binding binding = boundColumn.Binding as Binding;
            string boundPropertyName = binding.Path.Path;
            return boundPropertyName;
        }
    }
    // This XAML and C# where extracted from a link contained on this URL:    
    //    http://social.msdn.microsoft.com/Forums/en/wpf/thread/61707b8a-e6c6-474b-ac2b-3446319625bd

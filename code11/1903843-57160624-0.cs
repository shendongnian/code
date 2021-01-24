        private static T GetChildOfType<T>(DependencyObject depObj)
            where T : DependencyObject
        {
            if (depObj == null) return null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }
        private void DataGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = GetChildOfType<ScrollViewer>((DependencyObject)sender);
            int firstRow = (int)scroll.VerticalOffset;
            int lastRow = (int)scroll.VerticalOffset + (int)scroll.ViewportHeight + 1;
            DataGrid datagrid = sender as DataGrid;
            for (int i = firstRow; i < lastRow; i++)
            {
                var row = datagrid.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                if (row != null)
                {
                    var item = row.DataContext;
                    ItemViewModel viewModel = item as ItemViewModel;
                    if (viewModel != null)
                    {
                        viewModel.LoadImages().ContinueWith(t => { });
                    }
                }
            }
        }

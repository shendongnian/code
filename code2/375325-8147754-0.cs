    public static DataGridCell GetDataGridCell(DataGrid grid, int rowIndex, int colIndex)
    {
                DataGridCell result = null;
                DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(rowIndex);
                if (row != null)
                {
                    
                        DataGridCellsPresenter presenter = GetFirstVisualChild<DataGridCellsPresenter>(row);
                        result = presenter.ItemContainerGenerator.ContainerFromIndex(colIndex) as DataGridCell;
                    
                }
    
                return result;
    }
    
    public static T GetFirstVisualChild<T>(DependencyObject depObj)
            {
                if (depObj != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                        if (child != null && child is T)
                        {
                            return (T)child;
                        }
    
                        T childItem = GetFirstVisualChild(child);
                        if (childItem != null) return childItem;
                    }
                }
    
                return null;
            }

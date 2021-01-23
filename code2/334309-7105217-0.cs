     public DataGridCell GetCell(int column)
            {
                DataGridRow rowContainer = GetRow();
    
                if (rowContainer != null)
                {
                    DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
    
                    // Try to get the cell but it may possibly be virtualized.
                    DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                    if (cell == null)
                    {
                        // Now try to bring into view and retreive the cell.
                        customDataGrid.UCdataGridView.ScrollIntoView(rowContainer, customDataGrid.UCdataGridView.Columns[column]);
                        cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                    }
                    return cell;
                }
                return null;
            }
    
     public DataGridRow GetRow()
            {
                DataGridRow row = (DataGridRow)customDataGrid.UCdataGridView.ItemContainerGenerator.ContainerFromIndex(_currentRowIndex);
                if (row == null)
                {
                    // May be virtualized, bring into view and try again.
                    customDataGrid.UCdataGridView.UpdateLayout();
                    customDataGrid.UCdataGridView.ScrollIntoView(customDataGrid.UCdataGridView.Items[_currentRowIndex]);
                    row = (DataGridRow)customDataGrid.UCdataGridView.ItemContainerGenerator.ContainerFromIndex(_currentRowIndex);
                }
                return row;
            }
    
            public static T GetVisualChild<T>(Visual parent) where T : Visual
            {
                T child = default(T);
                int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < numVisuals; i++)
                {
                    Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                    child = v as T;
                    if (child == null)
                    {
                        child = GetVisualChild<T>(v);
                    }
                    if (child != null)
                    {
                        break;
                    }
                }
                return child;
            }
    // Setting Data to Grid Cell
    if (GetCell(3).Content is TextBlock) // if grid cell is not editable
    {
          ((TextBlock)(GetCell(3).Content)).Text = "sometext";
    }
    else // TextBox  - if grid cell is editable
    {
            ((TextBox)(GetCell(3).Content)).Text = "sometext";
    }

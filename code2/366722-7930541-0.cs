    Object obj = GetCell(3).Content;
                         string cellContent = String.Empty;
                         if (obj != null)
                         {
                             if (obj is TextBox)
                                 cellContent = ((TextBox)(obj)).Text;
                             else
                                 cellContent = ((TextBlock)(obj)).Text;
                          }
 
    private DataGridCell GetCell(int column)
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

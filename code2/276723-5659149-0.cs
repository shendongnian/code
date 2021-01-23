            private IInputElement lastDataGridFocus = null;
        private int selectedcolumnindex = 0;
        void grid_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (grid.Items.Count > 0 && (e.NewFocus is DataGrid || (e.NewFocus is DataGridCell && !(e.OldFocus is DataGridCell))))
            {
                DataGridCell cell = null;
                if (lastDataGridFocus != null)
                {
                    FocusManager.SetFocusedElement(grid, lastDataGridFocus);
                    lastDataGridFocus = null;
                    e.Handled = true;
                    return;
                }
                if (grid.SelectedCells.Count == 0)
                {
                    DataGridRow rowContainer = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(0);
                    if (rowContainer != null)
                    {
                        DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
                        cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex((selectedcolumnindex < 0) ? 0 : selectedcolumnindex);
                    }
                }
                else
                {
                    DataGridCellInfo selectedDataGridCellInfo = (grid.SelectedCells[0] as DataGridCellInfo?).Value;
                    DataGridRow rowContainer = (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(selectedDataGridCellInfo.Item);
                    if (rowContainer != null)
                    {
                        DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
                        cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex((selectedcolumnindex < 0) ? 0 : selectedcolumnindex);
                    }
                }
                if (null != cell)
                {
                    FocusManager.SetFocusedElement(grid, cell as IInputElement);
                    e.Handled = true;
                }
            }
        }
        void grid_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!(e.NewFocus is DataGridCell))
            {
                if (grid.CurrentCell != null)
                {
                    selectedcolumnindex = grid.Columns.IndexOf(grid.CurrentCell.Column);
                    //selectedcolumnindex = _dataGrid.CurrentCell.Column.DisplayIndex;
                }
            }
        }
        void grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.Tab)
            {
                lastDataGridFocus = Keyboard.FocusedElement;
                grid.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                e.Handled = true;
            }
            else if (Keyboard.Modifiers == ModifierKeys.None && e.Key == Key.Tab)
            {
                lastDataGridFocus = Keyboard.FocusedElement;
                grid.MoveFocus(new TraversalRequest(FocusNavigationDirection.Last));
                (Keyboard.FocusedElement as FrameworkElement).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                e.Handled = true;
            }
        }

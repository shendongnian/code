        private void GridMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;
            if (grid == null)
            {
                return;
            }
            // Assume first column is the checkbox column.
            if (grid.CurrentColumn == grid.Columns[0])
            {
                var gridCheckBox = (grid.CurrentColumn.GetCellContent(grid.SelectedItem) as CheckBox);
                if (gridCheckBox != null)
                {
                    gridCheckBox.IsChecked = !gridCheckBox.IsChecked;
                }
            }
        }

        private void dataGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (!_isEditing && e.Key == Key.Delete && Keyboard.Modifiers == ModifierKeys.None)
            {
                foreach (var cellInfo in dataGrid.SelectedCells)
                {
                   var column = cellInfo.Column as DataGridBoundColumn;
                   if (column != null)
                   {
                      var binding = column.Binding as Binding;
                      if (binding != null)
                          BindingHelper.SetSource(cellInfo.Item, binding, null);
                   }
                }
            }
        }

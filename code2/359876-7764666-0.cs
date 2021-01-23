        private void DataGrid_BeginningEdit(
            object sender,
            Microsoft.Windows.Controls.DataGridBeginningEditEventArgs e)
        {
            e.Cancel = GetCellValue(((DataGrid) sender).CurrentCell) == null;
        }
        private static object GetCellValue(DataGridCellInfo cell)
        {
            var boundItem = cell.Item;
            var binding = new Binding();
            if (cell.Column is DataGridTextColumn)
            {
                binding
                  = ((DataGridTextColumn)cell.Column).Binding
                        as Binding;
            }
            else if (cell.Column is DataGridCheckBoxColumn)
            {
                binding
                  = ((DataGridCheckBoxColumn)cell.Column).Binding
                        as Binding;
            }
            else if (cell.Column is DataGridComboBoxColumn)
            {
                binding
                    = ((DataGridComboBoxColumn)cell.Column).SelectedValueBinding
                         as Binding;
                if (binding == null)
                {
                    binding
                      = ((DataGridComboBoxColumn)cell.Column).SelectedItemBinding
                           as Binding;
                }
            }
            if (binding != null)
            {
                var propertyName = binding.Path.Path;
                var propInfo = boundItem.GetType().GetProperty(propertyName);
                return propInfo.GetValue(boundItem, new object[] {});
            }
            return null;
        }

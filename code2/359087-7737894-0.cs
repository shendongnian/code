     var boundItem = dataGrid2.CurrentCell.Item;
     //// If the column is datagrid text or checkbox column
     var binding = ((DataGridTextColumn)dataGrid2.CurrentCell.Column).Binding;
     var propertyName = binding.Path.Path;
     var propInfo = boundItem.GetType().GetProperty(propertyName);
     propInfo.SetValue(this, yourValue, new object[] {});

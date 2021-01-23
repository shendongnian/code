                foreach (var textColumn in dataGrid2.Columns.OfType<DataGridTextColumn>())
                {
                    var binding = textColumn.Binding as Binding;
                    if (binding != null)
                    {
                        var boundItem = dataGrid2.CurrentCell.Item;
                        var propertyName = binding.Path.Path;
                        var propInfo = boundItem.GetType().GetProperty(propertyName);
                        propInfo.SetValue(boundItem, NEWVALUE, new object[] { });
                    }
                }

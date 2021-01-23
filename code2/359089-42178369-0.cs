                foreach (var textColumn in Details.Columns.OfType<DataGridTextColumn>())
                {
                    var binding = textColumn.Binding as Binding;
                    if (binding != null)
                    {
                        var boundItem = Details.CurrentCell.Item;
                        var propertyName = binding.Path.Path;
                        var propInfo = boundItem.GetType().GetProperty(propertyName);
                        propInfo.SetValue(boundItem, NEWVALUE, new object[] { });
                    }
                }

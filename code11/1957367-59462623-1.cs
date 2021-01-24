    var currentItem = dataGrid.CurrentItem;
    int currentRowIndex = dataGrid.Items.IndexOf(currentItem);
    if (currentRowIndex <= 0) return;
    var previousItem = dataGrid.Items[currentRowIndex - 1] as YourDataObject;
    string propertyName = null;
    DataGridBoundColumn boundColumn = dataGrid.CurrentColumn as DataGridBoundColumn;
    if (boundColumn != null)
    {
        var binding = boundColumn.Binding as Binding;
        if (binding != null)
        {
            propertyName = binding.Path.Path;
        }
    }
    else if (dataGrid.CurrentColumn is DataGridTemplateColumn)
    {
        propertyName = dataGrid.CurrentColumn.SortMemberPath;
    }
    if (propertyName != null)
    {
        var property = typeof(YourDataObject).GetProperty(propertyName);
        var value = property.GetValue(previousItem);
        property.SetValue(currentItem, value);
    }

    var listItemType = property.PropertyType.GetGenericArguments().First();
    var clearMethod = property.PropertyType.GetMethod("Clear");
    var addMethod = property.PropertyType.GetMethod("Add");
    var listSelector = EditorPanel.FindControl(property.Name) as PropertyListBox;
    if (listSelector != null)
    {
        clearMethod.Invoke(property.GetValue(itemToUpdate, null), null);
        foreach (var selectedItem in listSelector.SelectedItems)
        {
            addMethod.Invoke(property.GetValue(itemToUpdate, null), new[] {selectedItem});
        }
    }

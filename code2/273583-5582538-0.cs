    var properties = dataTableColumnNames
            .Select(listItemType.GetProperty)
            .OfType<PropertyInfo>() // drop null values
            .ToList();
    listItems.ForEach(item => {
        var dataRow = dataTable.NewRow();
        properties.ForEach(property =>
                dataRow[property.Name] = property.GetValue(item, null));
        dataTable.Rows.Add(dataRow);
    });

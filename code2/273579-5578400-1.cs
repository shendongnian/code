    listItem
        .Select(item => 
            {
                var dataRow = dataTable.NewRow();
                dataTableColumnNames
                   .Select(col => listType.GetProperty(col))
                   .Where(p => p != null)
                   .ForEach(p => dataRow[p.Name] = p.GetValue(item, null));
                return row;
            })
        .ForEach(row => dataTable.Rows.Add(row));

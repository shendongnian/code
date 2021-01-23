    foreach (var entry in newEntities)
    {
        if (entry.State == EntityState.Added)
        {
            // continue and get property list
            var currentValues = entry.CurrentValues;
            for (var i = 0; i < currentValues.FieldCount; i++)
            {
                var fName = currentValues.DataRecordInfo.FieldMetadata[i].FieldType.Name;
                var fCurrVal = currentValues[i];
            }
        }
    }

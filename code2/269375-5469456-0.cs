        for(int i = 0;i<dt.Columns.Count;i++)
        {
            if(!selectedColumns.Contains(dt.Columns[i].ColumnName))
            {
                dt.Columns[i].ColumnMapping = MappingType.Hidden;
            }
        }

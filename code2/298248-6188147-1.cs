    bool flag = false;
    if (dtFirst.Columns.Count == dtSecond.Columns.Count)
    {
        for (int i = 0; i <= dtFirst.Columns.Count - 1; i++)
        {
            String colName = dtFirst.Columns[i].ColumnName;
            var colDataType = dtFirst.Columns[i].DataType.GetType();
            var colValue = dtFirst.Columns[i];
            flag = dtSecond.AsEnumerable().Any(T => typeof(T).GetProperty(colName).GetValue(T, typeof(colDataType)) == colValue);
        }
    }

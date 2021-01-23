    private IEnumerable<T> ConvertDataTableToGenericList(DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            yield return MapObject(row);
        }
    }

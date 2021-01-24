    public static CustomRow ToCustomRow(this row)
    {
        var values = row.Cells.ToDictionary(cell => cell.Name);
        int.TryParse(values.GetValueOrDefault("prop3"), out var prop3);
        DateTime.TryParse(values.GetValueOrDefault("prop4"), out var prop4);
        return new CustomRow
        {
            prop1 = values.GetValueOrDefault("prop1"),
            prop2 = values.GetValueOrDefault("prop2"),
            prop3 = prop3,
            prop4 = prop4
    }

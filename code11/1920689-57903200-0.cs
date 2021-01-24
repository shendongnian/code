    public ViewModel()
    {
        Table.Columns.Add("A");
        Table.Columns.Add("B");
        Table.Columns.Add("C");
        Table.Columns.Add("D");
        Table.Columns.Add("E");
        Table.Columns.Add("MyBackground");
        for (int i = 0; i < 10; i++)
        {
            Table.Rows.Add($"A-{i}", $"B-{i}", $"C-{i}", $"D-{i}", $"E-{i}", "Yellow");
        }
	...
    }

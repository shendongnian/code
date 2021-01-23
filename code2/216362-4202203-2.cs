    private readonly List<string> RowNames = new List<string> { "A1", "B1", "C1" };
    private readonly List<string> ColumnNames = new List<string> { "A", "B", "C" };
    private readonly int[,] Values = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
    public int this[string row, string column]
    {
        get
        {
            int rowIndex = RowNames.IndexOf(row);
            if (rowIndex == -1)
            {
                throw new ArgumentOutOfRangeException("Invalid row specified");
            }
            int columnIndex = ColumnNames.IndexOf(column);
            if (columnIndex == -1)
            {
                throw new ArgumentOutOfRangeException("Invalid column specified");
            }
            return Values[rowIndex, columnIndex];
        }
    }
    

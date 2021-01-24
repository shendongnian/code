    var columnCount = columns.Length;
    var rowCount = columns[0].Length;
    object Getter(int row, int col)
    {
        bool outOfBounds = (row >= columns[col].Length);
        return outOfBounds ? null : columns[col][row];
    }
    object[][] target = new object[rowCount][];
    for (int row = 0; row < rowCount; row++)
    {
        target[row] = new object[columnCount];
        for (int col = 0; col < columnCount; col++)
        {
            var cellValue = Getter(row, col);
            target[row][columnCount] = cellValue;
        }
    }

    object[][] target = new object[rowCount][];
    for (int row = 0; row < columns[0].Length; row++)
    {
        target[row] = new object[columnCount];
        for (int col = 0; col < columns.Length; col++)
        {
            var cellValue = Getter(row, col);
            target[row][columnCount] = cellValue;
        }
    }

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

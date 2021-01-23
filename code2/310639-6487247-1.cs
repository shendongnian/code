    public IEnumerable<int> GetAllCellsInColumn(Int32 column)
    {
        for(int row = 0; row < maxRow; row++)
            yield return cells[row, column];
    }

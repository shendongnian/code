    private static List<T> GetNeighbors<T>(int cellRow, int cellCol, T[,] grid)
    {
        var minRow = cellRow == 0 ? 0 : cellRow - 1;
        var maxRow = cellRow == grid.GetUpperBound(0) ? cellRow : cellRow + 1;
        var minCol = cellCol == 0 ? 0 : cellCol - 1;
        var maxCol = cellCol == grid.GetUpperBound(1) ? cellCol : cellCol + 1;
        var results = new List<T>();
        for (int row = minRow; row <= maxRow; row++)
        {
            for (int col = minCol; col <= maxCol; col++)
            {
                if (row == cellRow && col == cellCol) continue;
                results.Add(grid[row, col]);
            }
        }
        return results;
    }

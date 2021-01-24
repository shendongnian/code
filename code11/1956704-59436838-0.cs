    private void printBoard(DataGridView dgv, int[,] board)
    {
        var columns = board.GetUpperBound(1) + 1;
        var rows = board.GetUpperBound(0) + 1;
        for (int i = 0; i < columns; i++)
        {
            dgv.Columns.Add($"{i}", $"{i + 1}");
        }
        for (int i = 0; i < rows; i++)
        {
            dgv.Rows.Add(Enumerable.Range(0, columns).Select(x => (object)board[i, x]).ToArray());
        }
    }

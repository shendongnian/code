    private void printBoard(DataGridView dgv, int[,] board)
    {
        var columns = board.GetUpperBound(1) + 1; //Number of columns
        var rows = board.GetUpperBound(0) + 1;    //Number of rows
        //Add columns (name, text)
        for (int c = 0; c < columns; c++)
        {
            dgv.Columns.Add($"{c + 1}", $"{c + 1}"); 
        }
        //Add rows
        for (int r = 0; r < rows; r++)
        {
            //Slice 2d array and get the row
            var row = Enumerable.Range(0, columns).Select(c => (object)board[r, c]).ToArray();
            //Add the row
            dgv.Rows.Add(row);
        }
    }

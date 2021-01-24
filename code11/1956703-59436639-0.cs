    private void printBoard(int[,] board, int N)
    {
        // create columns
        dataGridView1.ColumnCount = N;
        for (int c = 0; c < N; c++)
            dataGridView1.Columns[c].Name = c.ToString();
        // create N empty rows
        dataGridView1.Rows.Add(N);
        // fill cells
        for (int r = 0; r < N; r++)
        {
            for (int c = 0; c < N; c++)
            {              
                dataGridView1[c, r].Value = board[r, c];
            }
        }
    }

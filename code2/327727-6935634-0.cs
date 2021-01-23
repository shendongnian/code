    private void button1_Click(object sender, EventArgs e)
    {
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
				Sudoku[x, y] = Convert.ToInt32(numericUpDown[x, y].Value);
            }
        }
    }

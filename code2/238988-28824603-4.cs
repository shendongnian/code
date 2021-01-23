    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 1)
        {
            int RowHeight1 = DataGridView1.Rows[e.RowIndex].Height;
            Rectangle CellRectangle1 = DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
    
            CellRectangle1.X += DataGridView1.Left;
            CellRectangle1.Y += DataGridView1.Top + RowHeight1;
    
            Point DisplayPoint1 = PointToScreen(new Point(CellRectangle1.X, CellRectangle1.Y));
            checkedListBox1.Left = CellRectangle1.X;
            checkedListBox1.Top = CellRectangle1.Y;
        }
    }

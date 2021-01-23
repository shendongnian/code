     private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewTextBoxCell cell in dataGridView1.SelectedCells)
            {
                if (cell.ColumnIndex > -1)
                {
                    table.Rows.RemoveAt(cell.ColumnIndex);
                }
            }
        }
